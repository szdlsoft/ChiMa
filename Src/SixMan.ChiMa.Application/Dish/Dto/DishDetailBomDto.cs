using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(DishBom))]
    public class DetailDishBomDto
        : MobileBaseDto
    {
        /// <summary>
        /// 字表顺序
        /// </summary>
        public int Order { get; set; } 
        /// <summary>
        /// 食材名称
        /// </summary>
        public string FoodMaterialName { get; set; }
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
