using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Extensions
{
    public static class DataTimeExtensions
    {
        public static DateTime GetDateZero(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day);
        }
    }
}
