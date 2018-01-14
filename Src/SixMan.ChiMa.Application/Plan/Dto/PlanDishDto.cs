using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Dish))]
    public class PlanDishDto
        : MobileBaseDto
    {
        public string Description { get; set; }
        /// <summary>
        /// 烹饪时间
        /// </summary>
        public int? CookTime { get; set; }
        /// <summary>
        /// 制作难度
        /// </summary>
        public int? Difficulty { get; set; }
        /// <summary>
        /// 星数
        /// </summary>
        public int? Star { get; set; }

        /// <summary>
        /// 横向图
        /// </summary>
        public string HPhoto { get; set; }

        /// <summary>
        /// 大图
        /// </summary>
        public string BPhoto { get; set; }


        /// <summary>
        /// 用户评论数
        /// </summary>
        public int UserCommentCount { get; set; }
        /// <summary>
        /// 用户喜欢数
        /// </summary>
        public int UserUserFavoriteCount { get; set; }
        /// <summary>
        /// 我是否喜欢
        /// </summary>
        public bool IsMyFavorite { get; set; }
        /// <summary>
        /// 今日上桌数
        /// </summary>
        public int ServeDishesCount { get; set; }
    }
}
