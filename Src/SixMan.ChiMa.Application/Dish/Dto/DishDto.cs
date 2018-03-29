using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Dish))]
    public class DishDto
         : MultiMediaBaseDto
    {
        /// <summary>
        /// 英文名称
        /// </summary>
        [Display(Name = "英文名称", Order = 10)] public string EnglishName { get; set; }       /// <summary>
        /// <summary>
        /// 烹饪方式
        /// </summary>
        [Display(Name = "烹饪方式", Order = 11)] public string CookMethod { get; set; }        /// 导入id
        /// <summary>
        /// 食材配比
        /// </summary>
        [Display(Name = "食材配比", Order = 1)] public ICollection<DishBomDto> DishBoms { get; set; }       
               /// 防止重复导入
        /// </summary>
        public long? ImportId { get; set; }
        /// <summary>
        /// 菜系
        /// </summary>
        [Display(Name = "类别", Order = 13)] public string DishCategory { get; set; }
 
        /// <summary>
        /// 口味
        /// </summary>
        [Display(Name = "口味", Order = 14)] public string Taste { get; set; }
        /// <summary>
        /// 预处理时间
        /// </summary>
        [Display(Name = "预处理时间", Order = 15)] public int? PreProcessTime { get; set; }
        /// <summary>
        /// 烹饪时间
        /// </summary>
        [Display(Name = "烹饪时间", Order = 16)] public int? CookTime { get; set; }
        [Display(Name = "制作难度", Order = 16)] public int? Difficulty { get; set; }
        [Display(Name = "星数", Order = 16)] public int? Star { get; set; }
        [Display(Name = "横向图", Order = 16)] public string HPhoto { get; set; }
        [Display(Name = "大图", Order = 16)] public string BPhoto { get; set; }
    }
}
