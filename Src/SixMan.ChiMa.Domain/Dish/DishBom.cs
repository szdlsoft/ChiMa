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
        /// 配比
        /// </summary>
        public double Matching { get; set; }
    }
}
