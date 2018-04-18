using Abp.Quartz;
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
                Logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ExecuteImp(IJobExecutionContext context)
        {
            //爬类别
            DishCategoryRawData dcr = GetDishCategoryRawData();
            if (dcr == null)
            {
                CrawlDishCategory();
                return;
            }
            //爬列表
            foreach( var dcrItem in dcr)
            {
                if(dcrItem.NeedCrawl)
                {
                    CrawDishList(dcrItem);
                }
                if( UserBreaker())
                {
                    return;
                }
            }

            //爬详情
            DishListRawData dlr = GetCrawDishList();
            foreach( var dlrItem in dlr)
            {
                CrawlDishDetails(dlrItem); //同时写数据库
                if (UserBreaker())
                {
                    return;
                }
            }

            //爬img
            DishDetailsRawData dir = GetDishDetails();
            foreach( var dirItem in dir)
            {
                CrawlDishImage(dirItem);
                if (UserBreaker())
                {
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

        private void CrawlDishCategory()
        {
            DishCategoryRawData data = CrawDishCategoryData();
            SerializeHelper.Save<DishCategoryRawData>("Dish", "DishCategory");
        }

        private DishCategoryRawData CrawDishCategoryData()
        {
            throw new NotImplementedException();
        }

        private void CrawDishList(DishCategoryRawDataItem dcrItem)
        {
        }

        private DishListRawData GetCrawDishList()
        {
            // 获取需要下载列表文件
            // 一次只 下一个
            return null;
        }

        private void CrawlDishDetails(DishListRawDataItem dlrItem)
        {
        }

        private DishDetailsRawData GetDishDetails()
        {
            // 从 DishDetailsRawData 获取img
            return null;
        }

        private void CrawlDishImage(DishDetailsRawDataItem dirItem)
        {
            // 每次下载1000个！
            //并发下载
        }
    }
}
