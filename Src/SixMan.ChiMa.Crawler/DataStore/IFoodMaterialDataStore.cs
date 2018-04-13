using SixMan.ChiMa.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    public interface IFoodMaterialDataStore
        : Abp.Dependency.ISingletonDependency
    {
        bool HasSave(string topCatName, string middleCatName);
        void SaveCategory(FoodMaterialRawDataItem item);
    }

    public class NullFoodMaterialDataStore : IFoodMaterialDataStore
    {
        public static IFoodMaterialDataStore Instance = new NullFoodMaterialDataStore();
        public bool HasSave(string topCatName, string middleCatName)
        {
            return false;
        }

        public void SaveCategory(FoodMaterialRawDataItem item)
        {
        }
    }

}
