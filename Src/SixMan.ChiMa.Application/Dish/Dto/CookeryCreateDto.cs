using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Application.Dish
{
    [AutoMap(typeof(SixMan.ChiMa.Domain.Dish.Cookery))]
    public class CookeryCreateDto
    {
        public long DishId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public int? Time { get; set; }
        [Required]
        [MinLength(MultiMediaContentBase.MaxContentLength)]       
        public string Content { get; set; }
    }
}
