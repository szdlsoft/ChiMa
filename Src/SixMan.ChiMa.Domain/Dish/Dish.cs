using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// 导入id
        /// 防止重复导入
        /// </summary>
        public long? ImportId { get; set; }
        /// <summary>
        /// 菜系
        /// </summary>
        public string DishCategory { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 口味
        /// </summary>
        public string Taste { get; set; }
        /// <summary>
        /// 烹饪方式
        /// </summary>
        public string CookMethod { get; set; }
        
        /// <summary>
        /// 预处理时间
        /// </summary>
        public int? PreProcessTime { get; set; }
        /// <summary>
        /// 烹饪时间
        /// </summary>
        public int? CookTime { get; set; }
        /// <summary>
        /// 制作难度
        /// </summary>
        public int? Difficulty { get; set; }
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
        /// 星数
        /// </summary>
        public int? Star { get; set; }

        /// <summary>
        /// 横向图
        /// </summary>
        [StringLength(LengthConstants.MaxUrlLength)]
        public string HPhoto { get; set; }

        /// <summary>
        /// 大图
        /// </summary>
        [StringLength(LengthConstants.MaxUrlLength)]
        public string BPhoto { get; set; }
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
        /// <summary>
        /// 用户喜欢
        /// </summary>
        public ICollection<UserFavoriteDish> UserUserFavorites { get; set; }


    }
}
