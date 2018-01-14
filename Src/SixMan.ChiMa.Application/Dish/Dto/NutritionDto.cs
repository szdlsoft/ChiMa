using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    /// <summary>
    /// 营养含量
    /// </summary>
    public class NutritionDto
    {
        /// <summary>
        /// 营养素名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public double Volume { get; set; }
    }
}
