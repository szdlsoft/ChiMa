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
                CrawDishList(dcrItem);
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
            DishImageRawData dir = GetDishImage();
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
            throw new NotImplementedException();
        }

        private void CrawlDishCategory()
        {
            throw new NotImplementedException();
        }

        private void CrawDishList(DishCategoryRawDataItem dcrItem)
        {
            throw new NotImplementedException();
        }

        private DishListRawData GetCrawDishList()
        {
            throw new NotImplementedException();
        }

        private void CrawlDishDetails(DishListRawDataItem dlrItem)
        {
            throw new NotImplementedException();
        }

        private DishImageRawData GetDishImage()
        {
            throw new NotImplementedException();
        }

        private void CrawlDishImage(DishImageRawDataItem dirItem)
        {
            throw new NotImplementedException();
        }
    }
}
