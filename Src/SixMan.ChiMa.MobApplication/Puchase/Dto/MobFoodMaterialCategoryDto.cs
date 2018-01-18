using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    [AutoMap(typeof(FoodMaterialCategory))]
    public class MobFoodMaterialCategoryDto
    {
        public string Code { get; set; }
    }
}
