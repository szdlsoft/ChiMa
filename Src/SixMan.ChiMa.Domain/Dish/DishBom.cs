using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Dish
{
    /// <summary>
    /// 食材配比
    /// </summary>
    public class DishBom
        : ChiMaEntityBase
    {
        public long DishId { get; set; }

        public Dish Dish { get; set; }
        public long FoodMaterialId { get; set; }
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 配比，百分比
        /// </summary>
        public double Matching { get; set; }
        /// <summary>
        /// 预处理烹饪方法
        /// </summary>
        public string PreProcess { get; set; }
    }
}
