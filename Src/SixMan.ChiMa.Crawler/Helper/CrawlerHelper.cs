using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    public static class CrawlerHelper
    {
        internal static async System.Threading.Tasks.Task<IHtmlDocument> GetDocument(string url)
        {
            HttpHelpers httpHelpers = new HttpHelpers();
            HttpItems items = new HttpItems();
            //首页
            items.Url = url;//请求地址
            items.Method = "Get";//请求方式 
            HttpResults hr = await httpHelpers.GetHtmlAsync(items);
            //Console.WriteLine(hr.Html);
            var parser = new HtmlParser();
            var document = await parser.ParseAsync(hr.Html);

            return document;
        }
    }
}
