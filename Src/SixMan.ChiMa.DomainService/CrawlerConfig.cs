using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SixMan.ChiMa.DomainService
{
    public static class CrawlerConfig
    {
        public static string RootPath = "D:\\Work\\ChiMa\\Src\\SixMan.ChiMa.Web.Mvc\\wwwroot";
        public static bool NeedCrawlerFoodMaterial = true;
        public static bool NeedDownloadFoodMaterialImage = true;

        private static IConfigurationSection _appSetting = null;

        internal static void Load(IConfigurationRoot appConfiguration)
        {
            RootPath = appConfiguration.GetConfigStr("RootPath");
            NeedCrawlerFoodMaterial = appConfiguration.GetConfigBool("NeedCrawlerFoodMaterial");
            NeedDownloadFoodMaterialImage = appConfiguration.GetConfigBool("NeedDownloadFoodMaterialImage");

            _appSetting = appConfiguration.GetSection("ApplicationSet");
        }

        public static bool GetConfigBool( this IConfigurationRoot appConfiguration, string key)
        {
            return bool.Parse(appConfiguration.GetSection("ApplicationSet").GetSection(key).Value);
        }

        public static string GetConfigStr(this IConfigurationRoot appConfiguration, string key)
        {
            return appConfiguration.GetSection("ApplicationSet").GetSection(key).Value;
        }

        public static bool GetTaskEnabled( string name )
        {
            string strValue = _appSetting.GetSection(name).Value ?? "true";
            return bool.Parse(strValue);
        }
    }
}
