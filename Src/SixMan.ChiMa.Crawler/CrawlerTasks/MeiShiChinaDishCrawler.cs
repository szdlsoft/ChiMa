using Abp.Quartz;
using AngleSharp.Dom.Html;
using Quartz;
using SixMan.ChiMa.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    public class MeiShiChinaDishCrawler
        : JobBase
         , ICrawlerTask
    {
        public Type TaskType => typeof(MeiShiChinaDishCrawler);

        public string Name => "MeiShiChinaDish";

        public void ConfigureJob(JobBuilder job)
        {
            job.WithIdentity("美食天下", "菜谱")
               .WithDescription("美食天下");
        }

        public void ConfigureTrigger(TriggerBuilder trigger)
        {
            trigger.StartNow()
                       .WithSimpleSchedule(schedule =>
                       {
                           schedule.RepeatForever()
                               .WithIntervalInHours(24)
                               .Build();
                       });
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //var publishTime = priceManager.GetLatest(Area);
                Console.WriteLine("开始 美食天下的菜谱。。。。");
                var startTime = DateTime.Now;
                await ExecuteImp(context);
                Console.WriteLine("结束 爬美食天下的菜谱  ");
                Logger.Info($"导入美食天下的菜谱总耗时：{DateTime.Now.Subtract(startTime).TotalSeconds}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ExecuteImp(IJobExecutionContext context)
        {
            //1 爬类别
            DishCategoryRawData dcr = GetDishCategoryRawData();
            if (dcr == null)
            {
                await CrawlDishCategory();
                // 经过手工修改，再进入 2
                return;
            }
            //2 爬列表
            foreach( var dcrItem in dcr)
            {
                if(dcrItem.NeedCrawl)
                {
                    CrawDishList(dcrItem);
                }
                if( UserBreaker())
                {
                    //可以按类别分别下
                    //该下的下完，再进入 3
                    return;
                }
            }

            //3 爬详情
            DishListRawData dlr = GetCrawDishList();
            foreach( var dlrItem in dlr)
            {
                CrawlDishDetails(dlrItem); 
                if (UserBreaker())
                {
                    // 必须全部下完，才进入 4
                    return;
                }
            }

            //4 爬img
            DishListRawData dir = GetDishDetails();
            foreach( var dirItem in dir)
            {
                CrawlDishImage(dirItem);
                if (UserBreaker())
                {
                    // 每次必须完成下一个类别
                    // 显示进度，很关键
                    return;
                }
            }


        }

        private bool UserBreaker()
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadKey(true).Key == ConsoleKey.F1;
            }

            return false;
        }

        private DishCategoryRawData GetDishCategoryRawData()
        {
            return SerializeHelper.Get<DishCategoryRawData>("Dish","DishCategory");
        }

        private async Task CrawlDishCategory()
        {
            DishCategoryRawData cates = new DishCategoryRawData();

            IHtmlDocument doc = await CrawlerHelper.GetDocumentASync("https://home.meishichina.com/recipe-type.html");
            var divs = doc.QuerySelectorAll(".category_sub.clear"); // 找出顶级分类
            Logger.Info($"找到菜品顶级分类: {divs.Length } 个");

            foreach (var topDiv in divs) // 
            {
                string topTag = topDiv.FirstElementChild.TextContent.Replace("/",",");
                var links = topDiv.FirstElementChild.NextElementSibling.GetElementsByTagName("a");
                Console.Write(topTag);
                foreach ( var a in links)
                {
                    string listUrl = a.GetAttribute("href");
                    cates.Add(new DishCategoryRawDataItem()
                    {
                        Tag = topTag + "," + a.GetAttribute("title")??a.TextContent,
                        ListUrl = listUrl,
                        PagesNumber = GetPageNumber(listUrl),
                    });
                    Console.Write(".");
                }
                Console.WriteLine("");
            }

            SerializeHelper.Save("Dish", "DishCategory", cates);
        }
        /// <summary>
        /// https://home.meishichina.com/recipe/huoguo/page/40/
        /// 取出40部分
        /// </summary>
        /// <param name="listUrl"></param>
        /// <returns></returns>
        private int GetPageNumber(string listUrl)
        {
            int pageNumber = 0;

            string ridectUrl = CrawlerHelper.GetRedirectUrl("https:" + listUrl + "page/200/");

            int len = ridectUrl.Length - 1;
            if (len < 1 || ! ridectUrl.Contains("page/"))
            {
                return pageNumber;
            } 

            string temp = ridectUrl.Substring(0, len);
            int pos = temp.LastIndexOf('/');

            int.TryParse(temp.Substring(pos+1), out pageNumber);
            return pageNumber;
        }

        private void CrawDishList(DishCategoryRawDataItem dcrItem)
        {
            //如果已存在该列表的文件，就pass
            Console.WriteLine(dcrItem.FileName);
            if(SerializeHelper.Exist("Dish", dcrItem.FileName))
            {
                Console.WriteLine("已下载");
                return;
            }

            DishDetailsRawData dishDatas = new DishDetailsRawData()
            {
                Tag = dcrItem.Tag,
            };
            // 按分页page 读取列表


            SerializeHelper.Save("Dish" , dcrItem.FileName, dishDatas);
        }

        private DishListRawData GetCrawDishList()
        {
            // 获取需要下载列表文件
            // 一次只 下一个
            return null;
        }

        private void CrawlDishDetails(DishDetailsRawData dlrItem)
        {
            //如果已存在该列表的文件，就pass
            //关键是相关信息和图片路径
        }

        private DishListRawData GetDishDetails()
        {
            // 从 DishDetailsRawData 获取img
            // 已经填好小图和大图了！
            // 按规则排序，便于分页处理
            return null;
        }

        private void CrawlDishImage(DishDetailsRawData dirItem)
        {
            // 每次下载1000个！
            //并发下载
            //如果已存在，就不下
        }
    }
}
