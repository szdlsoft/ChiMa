﻿using Abp.Quartz;
using AngleSharp.Dom.Html;
using Quartz;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Extensions;
using SixMan.ChiMa.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    public class MeiShiChinaDishCrawler
        : JobBase
         , ICrawlerTask
    {
        public ICrawlerDataStoreFactory _crawlerDataStoreBFactory { get; set; }
        public Type TaskType => typeof(MeiShiChinaDishCrawler);

        public string Name => "MeiShiChinaDish";

        ICrawlerDataStore DishFileStore;
        ICrawlerDataStore DishDetailsFileStore;

        public MeiShiChinaDishCrawler(ICrawlerDataStoreFactory crawlerDataStoreBFactory)
        {
            _crawlerDataStoreBFactory = crawlerDataStoreBFactory;
            DishFileStore = crawlerDataStoreBFactory.Create("Dish");
            DishDetailsFileStore = crawlerDataStoreBFactory.Create("DishDetails");

        }

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

        public bool OnlyOneTime => true;

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
            List<Task> tasks = new List<Task>();
            foreach( var dcrItem in dcr)
            {
                if(dcrItem.NeedCrawl)
                {
                    var task = CrawDishList(dcrItem);
                    tasks.Add(task);
                }
            }
            Task.WaitAll(tasks.ToArray());

            //3 爬详情
            tasks.Clear();
            var start = DateTime.Now;
            ShowAndLog($"爬详情 start:{start}");
            DishListRawData dlr = GetCrawDishList();
            foreach( var dlrItem in dlr)
            {
                tasks.Add( CrawlDishDetails(dlrItem)); 
                //if (UserBreaker())
                //{
                //    // 必须全部下完，才进入 4
                //    return;
                //}
            }
            Task.WaitAll(tasks.ToArray());
            var end = DateTime.Now;
            ShowAndLog($"爬详情 end:{end} 耗时:{end.Subtract(start).TotalMinutes}");

            //4 爬img
            //start = DateTime.Now;
            //ShowAndLog($"爬img start:{start}");
            //DishImgRawData imgs = GetDishDetails();
            //ParallelOptions parallelOptions = new ParallelOptions()
            //{
            //    MaxDegreeOfParallelism = 50,
            //};

            //Parallel.ForEach(imgs, parallelOptions
            //    , (img) =>
            //    {
            //        try
            //        {
            //            CrawlerHelper.DownloadImgAndSave(img);
            //            Console.Write(".");
            //        }
            //        catch(System.Net.WebException ex)
            //        {
            //            ShowAndLog($"{img.SourcrUrl}:{ex.Message}");
            //            Thread.Sleep(100);
            //        }
            //    } 
            //    );
            //end = DateTime.Now;
            //ShowAndLog($"爬img end:{end} 耗时:{end.Subtract(start).TotalMinutes}");

        }

        private void ShowAndLog(string msg)
        {
            Console.WriteLine(msg);
            Logger.Info(msg);
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

        private async Task CrawDishList(DishCategoryRawDataItem dcrItem)
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
            Console.WriteLine("");
            for (int page = 1; page <=50; page++)
            {
                string listFullUrl = $"https:{dcrItem.ListUrl}/page/{page}/";
                List<DishDetailsRawDataItem> pageDishs = await GetOnePageDishs(listFullUrl);
                dishDatas.AddRange(pageDishs);
            }

            SerializeHelper.Save("Dish" , dcrItem.FileName, dishDatas);
        }
        /// <summary>
        /// 爬一页菜品
        /// </summary>
        /// <param name="listFullUrl"></param>
        /// <returns></returns>
        private async Task< List<DishDetailsRawDataItem>> GetOnePageDishs(string listFullUrl)
        {
            Console.Write(listFullUrl);
            List<DishDetailsRawDataItem> pageDishs = new List<DishDetailsRawDataItem>();

            IHtmlDocument doc = await CrawlerHelper.GetDocumentASync(listFullUrl);
            var div = doc.QuerySelector("#J_list"); // 找出顶级分类
            if (div == null) return pageDishs;
            var lis = div.GetElementsByTagName("li");
            if(lis == null || lis.Length < 10)
            {
                return pageDishs;
            }
            foreach(var li in lis)
            {
                Console.Write(".");
                var link = li.GetElementsByTagName("a").First();
                pageDishs.Add(new DishDetailsRawDataItem()
                {
                    SmallImageUrl = li.GetElementsByTagName("img").First().GetAttribute("data-src"),
                    Name = link.GetAttribute("title"),
                    Url = link.GetAttribute("href"),
                    DataId = li.GetAttribute("data-id")
                });
            }
            Console.WriteLine("");

            return pageDishs;
        }

        private DishListRawData GetCrawDishList()
        {
            // 获取需要下载列表文件
            List<DishDetailsRawData> dishDetails = DishFileStore.GetByPrefix<DishDetailsRawData>("DishList",( item, objName )=> item.Tag = objName);
            DishListRawData data = new DishListRawData(dishDetails);

            // 一次只 下一个
            return data;
        }

        private async Task CrawlDishDetails(DishDetailsRawData dlr)
        {
            Console.Write($"{dlr.CrawlerFileName} ");
            //如果已存在该列表的文件，就pass
            if (DishDetailsFileStore.Exist(dlr))
            {
                Console.WriteLine($"已存在");
                return;
            }
            //关键是相关信息和图片路径
            //补充 还不完整的信息
            int max = 10;
            foreach( var item in dlr)
            {
                await FillDetail(item);
                Console.Write(".");

                //if (--max <= 0) break; //仅用于调试 
            }

            DishDetailsFileStore.Save(dlr);

            Console.WriteLine($"{dlr.CrawlerFileName} ok");
        }

        //补充 还不完整的信息
        private async Task FillDetail(DishDetailsRawDataItem detail)
        {
            IHtmlDocument doc = await CrawlerHelper.GetDocumentASync($"https:{detail.Url}");
            //大图
            var img = doc.QuerySelector(".J_photo img"); // 找出大图url
            detail.BigImageUrl = img?.GetAttribute("src");
            // 分类
            var tips = doc.QuerySelectorAll(".recipeTip.mt16");
            if( tips != null && tips.Length >= 3)
            {
                var links = tips[2].GetElementsByTagName("a");
                StringBuilder sb = new StringBuilder();
                foreach(var a in links)
                {
                    sb.Append( a.TextContent);
                    sb.Append(",");
                }
                detail.Tags = sb.ToString();
            }
            // 配比bom
            var particulars = doc.QuerySelectorAll(".particulars");
            if (particulars != null && particulars.Length >= 2)
            {
                var boms = particulars.Select(p =>
                   {
                       var bom = new DishBomRawData();
                       var bis = p.GetElementsByTagName("li").Select(li =>
                           {
                               var spans = li.Children;
                               if (spans != null && spans.Length >= 2)
                               {
                                   var bi = new BomItem()
                                   {
                                       EnglishName = CrawlerHelper.GetUrlLast(spans[0].FirstElementChild?.GetAttribute("href")),
                                       FoodMaterialName = spans[0].GetElementsByTagName("b").FirstOrDefault()?.TextContent,
                                       Use = spans[1].TextContent,
                                   };
                                  return bi;
                               }
                               else
                               {
                                   return new BomItem();
                               }
                           }
                        );
                       bom.AddRange(bis);
                       return bom;
                   }).ToList();
                if (boms != null && boms.Count >= 2)
                {
                    detail.DishBom = boms[0];
                    detail.AuxDishBom = boms[1];
                }
            }

            // 口味等
            var specs = doc.QuerySelectorAll(".recipeCategory_sub_R.mt30.clear li").Select(li =>
            {
                return li.GetElementsByTagName("a").FirstOrDefault()?.TextContent;
            }).ToList();
            if( specs !=null && specs.Count >=4 )
            {
                detail.Taste = specs[0];
                detail.Technology = specs[1];
                detail.CookTime = specs[2];
                detail.Difficulty = specs[3];
            }
            // 步骤
            var steps = doc.QuerySelectorAll(".recipeStep li").Select(li =>
           {
               string url = li.GetElementsByTagName("img").FirstOrDefault()?.GetAttribute("src");
               string content = li.LastElementChild?.TextContent;
               return new CookeyItem()
               {
                   Photo = url,
                   Content = content
               };
           }).ToList();

            detail.Cookery = new CookeryRawData(steps);

        }

        private DishImgRawData GetDishDetails()
        {
            // 从 DishDetailsRawData 获取img
            var dishCatDetails = new DishListRawData( DishDetailsFileStore.GetAll<DishDetailsRawData>());
            IEnumerable<DishImgItem> imgs = dishCatDetails.GetImgs();
            // 取掉重复
            return new DishImgRawData(imgs.Distinct());
        }
       

        //private void CrawlDishImage(DishDetailsRawData dirItem)
        //{
        //    // 每次下载1000个！
        //    //并发下载
        //    //如果已存在，就不下
        //}
    }
}
