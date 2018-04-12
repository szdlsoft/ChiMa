using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Food
{
    /// <summary>
    /// 食材营养素含量
    /// </summary>
    public  class FoodMaterialNutrition
        : ChiMaSmallEntityBase
    {
        public FoodMaterial FoodMaterial { get; set; }
        public Nutrition Nutrition { get; set; }
        /// <summary>
        /// 含量
        /// </summary>
        public double Content { get; set; }
    }
}
