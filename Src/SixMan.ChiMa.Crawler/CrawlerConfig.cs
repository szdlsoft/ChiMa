using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SixMan.ChiMa.Crawler
{
    public static class CrawlerConfig
    {
        public static string RootPath = "D:\\Work\\ChiMa\\Src\\SixMan.ChiMa.Web.Mvc\\wwwroot";
        public static bool NeedCrawlerFoodMaterial = true;
        public static bool NeedDownloadFoodMaterialImage = true;

        internal static void Load(IConfigurationRoot appConfiguration)
        {
            RootPath = appConfiguration.GetConfigStr("RootPath");
            NeedCrawlerFoodMaterial = appConfiguration.GetConfigBool("NeedCrawlerFoodMaterial");
            NeedDownloadFoodMaterialImage = appConfiguration.GetConfigBool("NeedDownloadFoodMaterialImage");
        }

        private static bool GetConfigBool( this IConfigurationRoot appConfiguration, string key)
        {
            return bool.Parse(appConfiguration.GetSection("ApplicationSet").GetSection(key).Value);
        }

        private static string GetConfigStr(this IConfigurationRoot appConfiguration, string key)
        {
            return appConfiguration.GetSection("ApplicationSet").GetSection(key).Value;
        }
    }
}
