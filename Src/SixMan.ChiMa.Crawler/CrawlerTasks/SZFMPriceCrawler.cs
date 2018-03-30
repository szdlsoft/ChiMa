using Abp.Dependency;
using Abp.Quartz;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    /// <summary>
    /// 苏州菜价爬虫
    /// </summary>
    public class SZFMPriceCrawler
        : JobBase
        , ICrawlerTask
    {
        public Type TaskType => typeof(SZFMPriceCrawler);

        public void ConfigureJob(JobBuilder job)
        {
            job.WithIdentity("苏州菜价行情", "菜价行情")
                             .WithDescription("苏州价格在线");
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

        public override async Task Execute(IJobExecutionContext context)
        {
            HttpHelpers httpHelpers = new HttpHelpers();
            HttpItems items = new HttpItems();
            //首页
            items.Url = "http://mssz.cn/newweb/index.jsp";//请求地址
            items.Method = "Get";//请求方式 post
            HttpResults hr = await httpHelpers.GetHtmlAsync(items);
            //Console.WriteLine(hr.Html);
            var parser = new HtmlParser();
            var document = await parser.ParseAsync(hr.Html);

            //价格页
            string priceUri = GetPriceUri(document);
            items.Url = priceUri;//请求地址
            hr = httpHelpers.GetHtml(items);

            document = parser.Parse(hr.Html);
            ShowPrice(document);
        }


        private  void Log(string title, string msg = null)
        {
            Logger.Info($"{title}:{msg}");
        }

        private  void ShowPrice(IHtmlDocument doc)
        {
            //var table = doc.All.Where( m => m.LocalName == "table"
            //                             && m.TextContent.Contains("苏州市部分农贸市场零售均价")
            //                          ).FirstOrDefault();
            var tds = doc.All.Where(m => m.LocalName == "td"
                                     && (m.ClassList.Contains("xl65")
                                        || m.ClassList.Contains("xl66"))
                                    ).ToList();
            foreach (var td in tds)
            {
                StringBuilder sb = new StringBuilder();
                IElement node = td;
                do
                {
                    sb.Append(node.TextContent + " ");
                    node = node.NextElementSibling;
                }
                while (node != null);

                Log("Price: ", sb.ToString());
            }
        }

        private  string GetPriceUri(IHtmlDocument htmlDocument)
        {
            string uri = htmlDocument.All.Where(m => m.LocalName == "a"
                                                  && m.TextContent.Contains("苏州市部分农贸市场零售均价"))
                                          .FirstOrDefault()?.GetAttribute("href");

            Log("GetPriceUri: ", uri);

            return uri;
        }
    }
}
