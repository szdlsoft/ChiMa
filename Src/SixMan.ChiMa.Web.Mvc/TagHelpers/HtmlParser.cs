using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.TagHelpers
{
    /// <summary>
    /// 解析html字符串
    /// </summary>
    public static class HtmlParser
    {
        /// <summary>
        /// 解析html字符串
        /// </summary>
        /// <param name="innnerHtml"></param>
        /// <returns></returns>
        internal static Dictionary<string, string> GetPropHtmls(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var divs = htmlDoc.DocumentNode.ChildNodes
                       .Where( node => node.Id.StartsWith("div_"))
                       .Select(node => new
                       {
                           id = node.Id.Substring("div_".Length)
                           , content = node
                       });

            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach ( var item in divs)
            {
                result[item.id] = item.content.OuterHtml;
            }

            return result;
        }
    }
}
