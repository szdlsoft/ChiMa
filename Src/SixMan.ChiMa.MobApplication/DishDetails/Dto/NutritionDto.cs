using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    /// <summary>
    /// 营养含量
    /// </summary>
    //[AutoMap(typeof(FoodMaterial))]
    public class NutritionDto
    {
        ///// <summary>
        ///// 能量_卡路里
        ///// </summary>
        //public double? EnergyKcal { get; set; }      
        ///// <summary>
        ///// 蛋白质
        ///// </summary>
        //public double? Protein { get; set; }
        ///// <summary>
        ///// 脂肪
        ///// </summary>
        //public double? Fat { get; set; }        
        ///// <summary>
        ///// 膳食纤维
        ///// </summary>
        //public double? Fibrin { get; set; }
        ///// <summary>
        ///// 胆固醇
        ///// </summary>
        //public double? Cholesterol { get; set; } 
        ///// <summary>
        ///// 钙
        ///// </summary>
        //public double? CA { get; set; }        
        ///// <summary>
        ///// 钾
        ///// </summary>
        //public double? K { get; set; }
        ///// <summary>
        ///// 纳
        ///// </summary>
        //public double? NA { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
    }
}
