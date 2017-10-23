﻿using Abp.Application.Services.Dto;
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
    }
}
