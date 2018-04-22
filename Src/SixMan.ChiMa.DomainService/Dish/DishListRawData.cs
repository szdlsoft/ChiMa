using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class DishListRawData
        : List<DishDetailsRawData>
    {
        public DishListRawData() { }

        public DishListRawData(List<DishDetailsRawData> dishDetails)
        {
            this.AddRange(dishDetails);
        }
    }

    //public class DishListRawDataItem
    //    : List<DishDetailsRawDataItem>
    //{        
    //    public string Tag { get; set; }        
    //}
}
