using Sixman.Chima.Domain.Base;
using Sixman.Chima.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sixman.Chima.Domain.Dish
{
    /// <summary>
    /// 菜品
    /// </summary>
    public class Dish
        : DescriptionBase
    {
        public long DishCategoryId { get; set; }
        /// <summary>
        /// 菜系
        /// </summary>
        public DishCategory DishCategory { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName { get; set; }
        public long TasteId { get; set; }
        /// <summary>
        /// 口味
        /// </summary>
        public Taste Taste { get; set; }
        public long CookMethodId { get; set; }
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
        /// 食材配比
        /// </summary>
        public ICollection<DishBom> DishBoms { get; set; }
        
        /// <summary>
        /// 烹饪法步骤
        /// </summary>
        public ICollection<Cookery> Cookerys { get; set; }
    }
}
