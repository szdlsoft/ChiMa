using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Dish
{
    /// <summary>
    /// 菜品
    /// </summary>
    public class Dish
        : MultiMediaBase
    {
        /// <summary>
        /// 菜系
        /// </summary>
        public DishCategory DishCategory { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 口味
        /// </summary>
        public Taste Taste { get; set; }
        /// <summary>
        /// 烹饪方式
        /// </summary>
        public CookMethod CookMethod { get; set; }
        
        /// <summary>
        /// 预处理时间
        /// </summary>
        public int? PreProcessTime { get; set; }
        /// <summary>
        /// 烹饪时间
        /// </summary>
        public int? CookTime { get; set; }
        /// <summary>
        /// 自制人
        /// 如为空表示是公共的
        /// </summary>
        public UserInfo HomeMadeUser { get; set; }
        /// <summary>
        /// 是否为公开，如不公开，仅在自制人可视
        /// </summary>
        public bool Public { get; set; }
        /// <summary>
        /// 食材配比
        /// </summary>
        public ICollection<DishBom> DishBoms { get; set; }
        
        /// <summary>
        /// 烹饪法步骤
        /// </summary>
        public ICollection<Cookery> Cookerys { get; set; }
        /// <summary>
        /// 用户评论
        /// </summary>
        public ICollection<UserCommentDish> UserComments { get; set; }
    }
}
