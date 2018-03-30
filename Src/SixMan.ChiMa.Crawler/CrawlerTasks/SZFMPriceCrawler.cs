﻿using Abp.Dependency;
using Abp.Quartz;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using Quartz;
using SixMan.ChiMa.Domain.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SixMan.ChiMa.Domain.Extensions;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    /// <summary>
    /// 苏州菜价爬虫
    /// </summary>
    public class SZFMPriceCrawler
        : CrawlerBase
        , ICrawlerTask
    {
        public Type TaskType => typeof(SZFMPriceCrawler);

        protected string Area => "苏州市";



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
            items.Method = "Get";//请求方式 
            HttpResults hr = await httpHelpers.GetHtmlAsync(items);
            //Console.WriteLine(hr.Html);
            var parser = new HtmlParser();
            var document = await parser.ParseAsync(hr.Html);

            DateTime publishTime = GetPublisTime(document);
            if( publishTime <= priceManager.GetLatest(Area))
            {
                return;
            }

            //价格页
            items.Url = GetPriceUri(document);
            hr = await httpHelpers.GetHtmlAsync(items);

            document = await parser.ParseAsync(hr.Html);
            //ShowPrice(document);
            IEnumerable<FMPriceItem> prices = GetPrices(document);
            priceManager.Save(Area, publishTime, prices);
        }

        private DateTime GetPublisTime(IHtmlDocument htmlDocument)
        {
            string dateStr = htmlDocument.All.Where(m => m.LocalName == "a"
                                                             && m.TextContent.Contains("苏州市部分农贸市场零售均价"))
                                                     .FirstOrDefault()?.TextContent.BracketsSub();

            Log("publish time: ", dateStr);

            return dateStr.ToDate();
        }

        private  void Log(string title, string msg = null)
        {
            Logger.Info($"{title}:{msg}");
        }

        private IEnumerable<FMPriceItem> GetPrices(IHtmlDocument doc)
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
                    var ss = node.TextContent.Split(' ', ' ');
                    if( ss.Length > 1)
                    {
                        yield return new FMPriceItem()
                        {
                            Name = ss[0],
                            Price = double.Parse(ss[1])
                        };
                    }

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