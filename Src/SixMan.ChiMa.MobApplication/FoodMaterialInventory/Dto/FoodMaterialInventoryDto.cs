using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    [AutoMap(typeof(FoodMaterialInventory))]
    public class FoodMaterialInventoryDto
        : MobileBaseDto
    {        
        /// <summary>
        /// 食材
        /// </summary>
        public MobFoodMaterialDto FoodMaterial { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int? Inventory { get; set; }


    }
}
