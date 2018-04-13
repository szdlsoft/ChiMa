using System;
using System.Collections.Generic;
using System.Text;
using SixMan.ChiMa.DomainService;

namespace SixMan.ChiMa.Crawler
{
    public class FoodMaterialDataStore
        : IFoodMaterialDataStore
    {
        private string GetLoaclFilePath(string topCatName, string middleCatName)
        {
            return System.IO.Path.Combine(CrawlerConfig.RootPath, @"CrawlerData\FoodMaterial", $"{topCatName}_{middleCatName}.json");
        }
        public bool HasSave(string topCatName, string middleCatName)
        {
            return System.IO.File.Exists(GetLoaclFilePath(topCatName, middleCatName));
        }

        public void SaveCategory(FoodMaterialRawDataItem item)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            using (var file = System.IO.File.CreateText(GetLoaclFilePath(item.Top, item.Middle)))
            {
                file.Write(json);
                file.Flush();
            }
        }
    }
}
