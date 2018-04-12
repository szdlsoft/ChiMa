using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace SixMan.ChiMa.Tests.Utils
{
    public class RegTest
    {
        [Fact]
        public void NutritionParse_Test()
        {
            string pattern = @"(?<name>\w+)\((?<unit>\w+)\)\s*\((?<content>\w+)\)";
            Regex rex = new Regex(pattern, RegexOptions.IgnoreCase);

            var matches = rex.Match("热量(大卡) (395)").Groups;

            var name = matches["name"];
            var content = matches["content"];
        }
    }
}
