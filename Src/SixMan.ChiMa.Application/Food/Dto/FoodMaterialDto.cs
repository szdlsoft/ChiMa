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
        //public FoodMaterialCategory FoodMaterialCategory { get; set; } 注意update时会发生'FoodMaterialCategory' 中的标识列插入显式值。
        /// <summary>
        /// 可食率
        /// </summary>
        [Display(Name = "可食率", Order = 10)]
        public int? EdiblePercent { get; set; }
        /// <summary>
        /// 水份
        /// </summary>
        [Display(Name = "水份", Order = 11)]
        public double? Water { get; set; }
        /// <summary>
        /// 能量_卡路里
        /// </summary>
        [Display(Name = "能量_卡路里", Order = 12)] public double? EnergyKcal { get; set; }
        /// <summary>
        /// 能量_焦耳
        /// </summary>
        [Display(Name = "能量_焦耳", Order = 13)] public double? EnergyKj { get; set; }
        /// <summary>
        /// 蛋白质
        /// </summary>
        [Display(Name = "蛋白质", Order = 14)] public double? Protein { get; set; }
        /// <summary>
        /// 脂肪
        /// </summary>
        [Display(Name = "脂肪", Order = 15)] public double? Fat { get; set; }
        /// <summary>
        /// 碳水化合物
        /// </summary>
        [Display(Name = "碳水化合物", Order = 16)] public double? CHO { get; set; }
        /// <summary>
        /// 膳食纤维
        /// </summary>
        [Display(Name = "膳食纤维", Order = 17)] public double? Fibrin { get; set; }
        /// <summary>
        /// 胆固醇
        /// </summary>
        [Display(Name = "胆固醇", Order = 18)] public double? Cholesterol { get; set; }
        /// <summary>
        /// 灰分
        /// </summary>
        [Display(Name = "灰分", Order = 19)] public double? ASH { get; set; }
        /// <summary>
        /// 维生素A
        /// </summary>
        [Display(Name = "维生素A", Order = 20)] public double? VitaminA { get; set; }
        /// <summary>
        /// 胡萝卜素
        /// </summary>
        [Display(Name = "胡萝卜素", Order = 21)] public double? Carotene { get; set; }
        /// <summary>
        /// 视黄素
        /// </summary>
        [Display(Name = "视黄素", Order = 22)] public double? Retinol { get; set; }
        /// <summary>
        /// 硫胺素
        /// </summary>
        [Display(Name = "硫胺素", Order = 23)] public double? Thiamin { get; set; }
        /// <summary>
        /// 维生素b2
        /// </summary>
        [Display(Name = "维生素b2", Order = 24)] public double? Riboflavin { get; set; }
        /// <summary>
        /// 尼克酸
        /// </summary>
        [Display(Name = "尼克酸", Order = 25)] public double? Niacin { get; set; }
        /// <summary>
        /// 维生素C
        /// </summary>
        [Display(Name = "维生素C", Order = 26)] public double? VitaminC { get; set; }
        /// <summary>
        /// 维生素E
        /// </summary>
        [Display(Name = "维生素E", Order = 27)] public double? VitaminE { get; set; }
        /// <summary>
        /// 钙
        /// </summary>
        [Display(Name = "钙", Order = 28)] public double? CA { get; set; }
        /// <summary>
        /// 磷
        /// </summary>
        [Display(Name = "磷", Order = 29)] public double? P { get; set; }
        /// <summary>
        /// 钾
        /// </summary>
        [Display(Name = "钾", Order = 30)] public double? K { get; set; }
        /// <summary>
        /// 纳
        /// </summary>
        [Display(Name = "纳", Order = 31)] public double? NA { get; set; }
        /// <summary>
        /// 镁
        /// </summary>
        [Display(Name = "镁", Order = 32)] public double? MG { get; set; }
        /// <summary>
        /// 铁
        /// </summary>
        [Display(Name = "铁", Order = 33)] public double? FE { get; set; }
        /// <summary>
        /// 锌
        /// </summary>
        [Display(Name = "锌", Order = 34)] public double? ZN { get; set; }
        /// <summary>
        /// 硒
        /// </summary>
        [Display(Name = "硒", Order = 35)] public double? SE { get; set; }
        /// <summary>
        /// 铜
        /// </summary>
        [Display(Name = "铜", Order = 36)] public double? CU { get; set; }
        /// <summary>
        /// 锰
        /// </summary>
        [Display(Name = "锰", Order = 37)] public double? MN { get; set; }

        /// <summary>
        /// 时令
        /// </summary>
        [StringLength(50)]
        [Display(Name = "时令", Order = 6)]
        public string Season { get; set; }
        [Display(Name = "分类", Order = 5)]
        public string Category { get; set; }
        public long? FoodMaterialCategoryId { get; set; }

    }
}
