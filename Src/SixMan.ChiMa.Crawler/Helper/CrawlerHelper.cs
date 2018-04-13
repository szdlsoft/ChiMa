using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler
{
    public static class CrawlerHelper
    {
        internal static async System.Threading.Tasks.Task<IHtmlDocument> GetDocumentASync(string url)
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



        /// <summary>
        /// 返回最后一段URL
        /// 例如： //www.meishichina.com/YuanLiao/ZhuQianJiaRou/  返回 ZhuQianJiaRou
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static string GetUrlLast(string url)
        {
            return url.Trim('/').Split('/').Last();
        }

        internal static Task<IHtmlDocument> GetDocumentAddHttpPrefixAsync(string url)
        {
            return GetDocumentASync($"http:{url}");
        }

        internal static async Task DownloadImgAndSaveAsync(string sourceImgUrl, string imagePath)
        {
            if( sourceImgUrl == null)
            {
                return;
            }
            string fullPath = Path.Combine(CrawlerConfig.RootPath,  imagePath);

            if (File.Exists(fullPath))
            {
                return;
            }

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(sourceImgUrl, fullPath);
            }

            //using (Image img = await GetImage(sourceImgUrl))
            //{
            //    img.Save(fullPath);
            //}

        }

        private static async Task<Image> GetImageASync(string sourceImgUrl)
        {
            System.Net.CookieContainer cc = new System.Net.CookieContainer();//自动处理Cookie对象
            HttpHelpers httpHelpers = new HttpHelpers();
            HttpItems items = new HttpItems();
            items.Url = sourceImgUrl;//请求地址
            items.Method = "Get";//请求方式 
            //items.IsGetImage = true;
            items.Container = cc;//自动处理Cookie时,每次提交时对cc赋值即可
            items.ResultType = ResultType.Byte;//设置请求返回值类型为Byte

            var hr = await httpHelpers.GetHtmlAsync(items);


            return  httpHelpers.GetImg(hr);
        }
    }
}
