using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    /// <summary>
    /// 食材导入
    /// </summary>
    public interface IFoodMaterialImportManager
    {
        void Import(FoodMaterialRawData rawData);
        bool HasImport(string topCatName, string middleCatName);
        void ImportCategory(FoodMaterialRawDataItem item);
    }

    public class NullFoodMaterialImportManager
        : IFoodMaterialImportManager
    {
        public static IFoodMaterialImportManager Instance = new NullFoodMaterialImportManager();

        public bool HasImport(string topCatName, string middleCatName)
        {
            return false;
        }

        public void Import(FoodMaterialRawData rawData)
        {
            
        }

        public void ImportCategory(FoodMaterialRawDataItem item)
        {
        }
    }
}
