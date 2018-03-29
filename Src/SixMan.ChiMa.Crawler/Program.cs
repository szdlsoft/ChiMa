using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Castle.Facilities.Logging;
using HttpCode.Core;
using System;
using System.Linq;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ChiMa Crawler start !");
            using (var bootstrapper = AbpBootstrapper.Create<ChiMaCrawlerModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                        .WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();
            }

            HttpHelpers httpHelpers = new HttpHelpers();
            HttpItems items = new HttpItems();
            //首页
            items.Url = "http://mssz.cn/newweb/index.jsp";//请求地址
            items.Method = "Get";//请求方式 post
            HttpResults hr = httpHelpers.GetHtml(items);
            //Console.WriteLine(hr.Html);
            var parser = new HtmlParser();
            var document = parser.Parse(hr.Html);

            //价格页
            string priceUri = GetPriceUri(document);
            items.Url = priceUri;//请求地址
            hr = httpHelpers.GetHtml(items);

            document = parser.Parse(hr.Html);
            ShowPrice(document);


            Console.WriteLine("Press ENTER to exit...");
            Console.ReadKey();

        }

        private static void Log(string title, string msg = null)
        {
            Console.WriteLine($"{title}:{msg}");
        } 

        private static void ShowPrice(IHtmlDocument doc)
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

        private static string GetPriceUri(IHtmlDocument htmlDocument)
        {
            string uri = htmlDocument.All.Where(m => m.LocalName == "a"
                                                  && m.TextContent.Contains("苏州市部分农贸市场零售均价"))
                                          .FirstOrDefault()?.GetAttribute("href");

            Log("GetPriceUri: ", uri);

            return uri;
        }
    }
}
