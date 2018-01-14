using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Extensions
{
    public static class IEnumerationExtenstion
    {
        public static void Map<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach( var item in source)
            {
                action(item);
            }
        }
    }
}
