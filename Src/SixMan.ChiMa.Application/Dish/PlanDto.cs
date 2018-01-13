using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Plan))]
    public class PlanDto
        : ChiMaEntityBaseDto
    {
        /// <summary>
        /// 家庭
        /// </summary>
        //public SixMan.ChiMa.Domain.Family.Family Family { get; set; }
        /// <summary>
        /// 菜谱
        /// </summary>
        public DishDto Dish { get; set; }
        /// <summary>
        /// 计划：年，月，日
        /// </summary>
        public DateTime PlanDate { get; set; }
        /// <summary>
        /// 类型索引号，
        /// </summary>
        public int KindNO { get; set; }
        /// <summary>
        /// 类型（早， 加1， 中， 加2，晚，加3），从1开始算
        /// </summary>
        public string Kinds { get; set; }
    }
}
