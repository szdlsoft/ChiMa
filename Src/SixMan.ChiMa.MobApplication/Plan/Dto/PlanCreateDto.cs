using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Plan))]
    public class PlanCreateDto
    {
        public long DishId { get; set; }
        public DateTime PlanDate { get; set; }
        public MealType MealType { get; set; }

    }
}
