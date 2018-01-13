using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace SixMan.ChiMa.Domain.Dish
{
    /// <summary>
    /// 菜谱计划
    /// </summary>
    public class Plan
        : ChiMaEntityBase
    {
        /// <summary>
        /// 家庭
        /// </summary>
        public SixMan.ChiMa.Domain.Family.Family Family { get; set; }
        /// <summary>
        /// 菜谱
        /// </summary>
        public Dish Dish { get; set; }
        /// <summary>
        /// 计划：年，月，日
        /// </summary>
        public DateTime PlanDate { get; set; }
        /// <summary>
        /// 餐别
        /// </summary>
        public MealType MealType { get; set; }
        /// <summary>
        /// 序号
        /// 在本餐中的第几个菜
        /// </summary>
        public int MealNo{ get; set; }
        /// <summary>
        /// 类型（早， 加1， 中， 加2，晚，加3），从1开始算
        ///// </summary>
        //[StringLength(DescriptionBase.MaxDescriptionLength)]
        //public string Kinds { get; set; }
    }
}
