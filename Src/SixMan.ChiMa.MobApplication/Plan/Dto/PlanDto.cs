using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Plan))]
    public class PlanDto
        : MobileBaseDto
    {
        /// <summary>
        /// 菜谱
        /// </summary>
        public PlanDishDto Dish { get; set; }
        /// <summary>
        /// 计划：年，月，日
        /// </summary>
        public DateTime PlanDate { get; set; }
        /// <summary>
        /// 餐别
        /// </summary>
        public string MealType { get; set; }
        /// <summary>
        /// 序号
        /// 在本餐中的第几个菜
        /// </summary>
        public int MealNo { get; set; }
    }
}
