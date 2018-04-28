using Newtonsoft.Json;
using SixMan.ChiMa.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    public static class SerializeHelper
    {
        private static string GetLoaclFilePath(string subDir, string fileName)
        {
            return System.IO.Path.Combine(ChiMaConfig.RootPath, @"CrawlerData",  subDir, $"{fileName}.json");
        }
        internal static T Get<T>(string subDir, string fileName )
        {
            string path = GetLoaclFilePath(subDir, fileName);
            if(System.IO.File.Exists(path))
            {
                using( var fs = System.IO.File.OpenText(path))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fs.ReadToEnd());
                }
            }

            return default(T);
        }

        internal static void Save<T>(string subDir, string fileName, T obj)
        {
            string path = GetLoaclFilePath(subDir, fileName);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting= Formatting.Indented,
            };
            var json = JsonConvert.SerializeObject(obj,settings);
            using (var file = System.IO.File.CreateText(path))
            {
                file.Write(json);
                file.Flush();
            }
        }

        internal static bool Exist(string path, string fileName)
        {
            return System.IO.File.Exists(GetLoaclFilePath(path, fileName));
        }
    }
}
