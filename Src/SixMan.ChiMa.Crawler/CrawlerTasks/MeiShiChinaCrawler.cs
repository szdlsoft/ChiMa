using Abp.Domain.Uow;
using Abp.Quartz;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    public class MeiShiChinaCrawler
         : JobBase
         , ICrawlerTask
    {
        public Type TaskType => typeof(MeiShiChinaCrawler);

        public void ConfigureJob(JobBuilder job)
        {
            job.WithIdentity("美食天下", "食材菜谱")
                                         .WithDescription("美食天下");
        }

        public void ConfigureTrigger(TriggerBuilder trigger)
        {
            trigger.StartNow()
            .WithSimpleSchedule(schedule =>
            {
                schedule.RepeatForever()
                    .WithIntervalInSeconds(600)
                    .Build();
            });
        }


        [UnitOfWork]
        public override async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //var publishTime = priceManager.GetLatest(Area);
                Console.WriteLine("开始 美食天下的食材菜谱。。。。");
                await ExecuteImp(context);
                Console.WriteLine("结束 爬美食天下的食材菜谱  ");
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task ExecuteImp(IJobExecutionContext context)
        {         

            IHtmlDocument doc = await CrawlerHelper.GetDocument( " http://www.meishichina.com/YuanLiao/");

            var lis = doc.QuerySelectorAll(".nav_wrap2 li a"); // 找出价格行

            Logger.Info($"找到食材顶级分类: {lis.Length -2} 个");

            for( int i =1; i <= lis.Length-2; i++) // 去掉一头一尾
            {
                ImportTopCategory(lis[i]);
            }

        }

        private async void ImportTopCategory(IElement element)
        {
            var topCatName = element.InnerHtml;
            var topCatUrl = element.GetAttribute("href");
            Logger.Info($"导入食材顶级分类: {topCatName} {topCatUrl}");

            var url = $"http:{topCatUrl}";

            var topDoc = await CrawlerHelper.GetDocument(url);

            var middleDivs = topDoc.QuerySelectorAll(".category_sub.clear");
            Logger.Info($"   有{middleDivs.Length} 中类 ");

            foreach( var midDiv in middleDivs)
            {
                StringBuilder sb = new StringBuilder();
                var middleName = midDiv.FirstElementChild.TextContent; //h2 // node 是可视树， element 是逻辑树
                var ul = midDiv.LastElementChild;  //ul

                sb.Append($"    {middleName} : ");
                foreach( var li in ul.GetElementsByTagName("li"))
                {
                    var a = li.FirstElementChild;
                    var littleCatName = a.TextContent;
                    var littleHref = a.GetAttribute("href");
                    sb.Append($" {littleCatName} {littleHref} ");
                }

                Logger.Info(sb.ToString());
            }


        }
    }
}
