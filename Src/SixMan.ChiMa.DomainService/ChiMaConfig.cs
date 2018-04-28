using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SixMan.ChiMa.DomainService
{
    public static class ChiMaConfig
    {
        public static string RootPath = "D:\\Work\\ChiMa\\Src\\SixMan.ChiMa.Web.Mvc\\wwwroot";
        public static bool NeedCrawlerFoodMaterial = true;
        public static bool NeedDownloadFoodMaterialImage = true;

        private static IConfigurationSection _appSetting = null;
        /// <summary>
        /// 短信模板
        /// </summary>
        public static string SMSTemplate { get; private set; }
        /// <summary>
        /// 短信存续时间
        /// </summary>
        public static int SMSTimeOfExistence { get; private set; }

        public static void Load(IConfigurationRoot appConfiguration)
        {
            _appSetting = appConfiguration.GetSection("ApplicationSet");

            RootPath = appConfiguration.GetConfigStr("RootPath");
            NeedCrawlerFoodMaterial = appConfiguration.GetConfigBool("NeedCrawlerFoodMaterial");
            NeedDownloadFoodMaterialImage = appConfiguration.GetConfigBool("NeedDownloadFoodMaterialImage");

            SMSTemplate = appConfiguration.GetConfigStr("SMSTemplate");
            SMSTimeOfExistence = appConfiguration.GetConfigInt("SMSTimeOfExistence");
        }

        private static bool GetConfigBool( this IConfigurationRoot appConfiguration, string key)
        {
            return bool.Parse(appConfiguration.GetSection("ApplicationSet").GetSection(key).Value);
        }

        private static string GetConfigStr(this IConfigurationRoot appConfiguration, string key)
        {
            return appConfiguration.GetSection("ApplicationSet").GetSection(key).Value;
        }

        private static int GetConfigInt(this IConfigurationRoot appConfiguration, string key)
        {
            return int.Parse( appConfiguration.GetSection("ApplicationSet").GetSection(key).Value);
        }

        public static bool GetTaskEnabled( string name )
        {
            string strValue = _appSetting.GetSection(name).Value ?? "true";
            return bool.Parse(strValue);
        }


    }
}
