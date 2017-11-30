using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.Domain.Interface;
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
        , IOrder
    {
        /// <summary>
        /// 字表顺序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 菜品
        /// </summary>
        public long DishId { get; set; }

        public Dish Dish { get; set; }
        /// <summary>
        /// 食材
        /// </summary>
        public long FoodMaterialId { get; set; }
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 配比，百分比
        /// 精确描述
        /// </summary>
        public double Matching { get; set; }
        /// <summary>
        /// 配比的任意描述
        /// </summary>
        public string MatchingDescription { get; set; }
        /// <summary>
        /// 预处理烹饪方法
        /// </summary>
        public string PreProcess { get; set; }
       
    }
}
