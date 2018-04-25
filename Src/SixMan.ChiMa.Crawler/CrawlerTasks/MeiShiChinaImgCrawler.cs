using Abp.Quartz;
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
    public class MeiShiChinaImgCrawler
        : JobBase
         , ICrawlerTask
    {
        public ICrawlerDataStoreFactory _crawlerDataStoreBFactory { get; set; }
        public Type TaskType => typeof(MeiShiChinaDishCrawler);

        public string Name => "MeiShiChinaImg";

        ICrawlerDataStore DishDetailsFileStore;

        public MeiShiChinaImgCrawler(ICrawlerDataStoreFactory crawlerDataStoreBFactory)
        {
            _crawlerDataStoreBFactory = crawlerDataStoreBFactory;
            DishDetailsFileStore = crawlerDataStoreBFactory.Create("DishDetails");

        }

        public void ConfigureJob(JobBuilder job)
        {
            job.WithIdentity("美食天下", "菜谱Img")
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
                Console.WriteLine("开始 美食天下的菜谱Img。。。。");
                var startTime = DateTime.Now;
                await ExecuteImp(context);
                Console.WriteLine("结束 爬美食天下的菜谱Img  ");
                Logger.Info($"导入美食天下的菜谱Img总耗时：{DateTime.Now.Subtract(startTime).TotalSeconds}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ExecuteImp(IJobExecutionContext context)
        {
            //4 爬img
            var start = DateTime.Now;
            ShowAndLog($"爬img start:{start}");
            DishImgRawData imgs = GetDishDetails();
            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 50,
            };

            Parallel.ForEach(imgs, parallelOptions
                , (img) =>
                {
                    try
                    {
                        CrawlerHelper.DownloadImgAndSave(img);
                        Console.Write(".");
                    }
                    catch(System.Net.WebException ex)
                    {
                        ShowAndLog($"{img.SourcrUrl}:{ex.Message} {ex.InnerException?.Message}");
                        Thread.Sleep(100);
                    }
                } 
                );
            var end = DateTime.Now;
            ShowAndLog($"爬img end:{end} 耗时:{end.Subtract(start).TotalMinutes}");

        }

        private void ShowAndLog(string msg)
        {
            Console.WriteLine(msg);
            Logger.Info(msg);
        }

      

        private DishImgRawData GetDishDetails()
        {
            // 从 DishDetailsRawData 获取img
            var dishCatDetails = new DishListRawData( DishDetailsFileStore.GetAll<DishDetailsRawData>());
            IEnumerable<DishImgItem> imgs = dishCatDetails.GetImgs();
            // 取掉重复
            return new DishImgRawData(imgs.Distinct());
        }       

    }
}
