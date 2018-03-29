using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Dish))]
    public class DishDetailsDto
        : MobileBaseDto
    {
        /// <summary>
        /// 食材配比
        /// </summary>
        public ICollection<DetailDishBomDto> DishBoms { get; set; }

        /// <summary>
        /// 营养含量
        /// </summary>
        public ICollection<NutritionDto> Nutritions { get; set; }

        /// <summary>
        /// 烹饪法步骤
        /// </summary>
        public ICollection<CookeryDto> Cookerys { get; set; }

    }
}
