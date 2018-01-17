using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    [AutoMap(typeof(FoodMaterial))]
    public class FoodMaterialDto
        : MobileMultiMediaBaseDto
    {
        public FoodMaterialCategoryDto FoodMaterialCategory { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double? Price { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 主材？
        /// </summary>
        public bool IsMain { get; set; }

    }
}
