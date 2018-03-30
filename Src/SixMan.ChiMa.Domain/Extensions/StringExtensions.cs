using Abp.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNullOrEmpty(this string str)
        {
            return !str.IsNullOrEmpty();
        }

        public static bool IsInList(this string str, IEnumerable<string> list)
        {
            return list.Any(item => string.Compare(item, str,true) == 0);
        }

        public static bool IsNotInList(this string str, IEnumerable<string> list)
        {
            return !IsInList(str,list);
        }

        public static bool IsCap(this string str)
        {
            return Regex.IsMatch(str, "^[A-Z]+$");
        }

        public static string ToJsonName(this string name)
        {
            if(  name.IsCap()) //如果是缩写
            {
                return name.ToLower();
            }
            else
            {
                return name.ToCamelCase();
            }
        }
        /// <summary>
        /// '/' 变 '\\'
        /// </summary>
        /// <param name="slashName"></param>
        /// <returns></returns>
        public static string ToAntiSlash(this string slashName)
        {
            return slashName.Replace('/', '\\');
        }
        /// <summary>
        /// 取括号中得内容
        /// 例如：  苏州市部分农贸市场零售均价（2018年03月29日） 得到：2018年03月29日
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string BracketsSub(this string str)
        {
            var start = str.IndexOfAny(new char[] { '(', '（' });
            var length = str.IndexOfAny(new char[] { ')', '）' }, start);

            return str.Substring(start + 1, length );
        }

        /// <summary>
        /// 解析2018年03月29日
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string str)
        {
            return DateTime.ParseExact(str, "yyyy年MM月DD日", CultureInfo.InvariantCulture);
        }
    }
}
