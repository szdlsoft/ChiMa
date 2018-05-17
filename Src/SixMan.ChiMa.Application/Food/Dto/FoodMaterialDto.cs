using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Food.Dto
{
    [AutoMap(typeof(FoodMaterial))]
    public class FoodMaterialDto
        : MultiMediaBaseDto
    {

        /// <summary>
        /// 时令
        /// </summary>
        [StringLength(50)]
        [Display(Name = "时令", Order = 6)]
        public string Season { get; set; }

        [DataType("ReadOnly")]
        //[Display(Name = "分类", Order = 5)]
        //public string Category { get; set; }
        [Display(Name = "分类", Order = 5)]
        public string FoodMaterialCategoryName { get; set; }

        public int? FoodMaterialCategoryIndexNo { get; set; }

        //public FoodMaterialCategoryDto FoodMaterialCategory { get; set; }

        public long? FoodMaterialCategoryId { get; set; }

        public bool HasImage { get; set; }

        public double? Price { get; set; }

    }
}
