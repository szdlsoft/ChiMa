using Abp.Events.Bus;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain
{
    public class FoodMaterialInventoryChangeEvent
        : EventData
    {
        public Family.Family Family { get; set; }
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 发生额
        /// + 为增 -为减
        /// </summary>
        public int? Volume { get; set; }       
    }
}
