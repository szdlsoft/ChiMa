using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Application.Food.Dto
{
    [AutoMap(typeof(FoodMaterialCategory))]
    public class FoodMaterialCategoryDto 
        :  EntityDto<long>
    { 
        [Required]
        [StringLength(CategoryBase.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(CategoryBase.MaxCodeLength)]
        public string Code { get; set; }

        /// <summary>
        /// 分类索引号 
        /// </summary>
        public int? IndexNo { get; set; }

        /// <summary>
        /// 单价
        ///// </summary>
        //public double? Price { get; set; }
        ///// <summary>
        ///// 单位
        ///// </summary>
        //public string Unit { get; set; }

        ///// <summary>
        ///// 库存
        ///// </summary>
        //public int? Inventory { get; set; }

        //分类索引号从 Category里获取
    }
}
