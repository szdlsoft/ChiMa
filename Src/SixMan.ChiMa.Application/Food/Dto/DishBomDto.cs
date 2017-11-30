using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Dish;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Food.Dto
{
    public class DishBomDto
       : EntityDto<long>
    {
        /// <summary>
        /// 字表顺序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 食材名称
        /// </summary>
        [Display(Name = "食材名称", Order = 10)] public string FoodMaterialName { get; set; }
        /// <summary>
        /// 配比，百分比
        /// 精确描述
        /// </summary>
        [Display(Name = "配比", Order = 11)] public double Matching { get; set; }
    }
}
