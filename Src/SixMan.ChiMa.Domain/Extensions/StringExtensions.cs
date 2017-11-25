using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
