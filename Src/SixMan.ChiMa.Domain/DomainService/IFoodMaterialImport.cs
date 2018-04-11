using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain
{
    /// <summary>
    /// 食材导入
    /// </summary>
    public interface IFoodMaterialImport
    {
        void Import(FoodMaterialRawData rawData);
    }

    public class NullFoodMaterialImport
        : IFoodMaterialImport
    {
        public static IFoodMaterialImport Instance = new NullFoodMaterialImport();
        public void Import(FoodMaterialRawData rawData)
        {
            
        }
    }
}
