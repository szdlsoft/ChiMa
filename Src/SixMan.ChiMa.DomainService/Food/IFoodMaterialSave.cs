using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public interface IFoodMaterialSave
    {
        bool HasSave(string topCatName, string middleCatName);
        void SaveCategory(FoodMaterialRawDataItem item);
    }
}
