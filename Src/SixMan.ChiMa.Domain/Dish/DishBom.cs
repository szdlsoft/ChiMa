using Sixman.Chima.Domain.Base;
using Sixman.Chima.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sixman.Chima.Domain.Dish
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
        /// </summary>biao
        public int Matching { get; set; }
        /// <summary>
        /// 配比方式，
        /// 0：百分比，用与主食材
        /// 1：模糊值，用于佐料食材
        /// </summary>
        public int MatchingType { get; set; }
    }
}
