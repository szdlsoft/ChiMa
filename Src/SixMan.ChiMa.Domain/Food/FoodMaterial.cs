﻿using Sixman.Chima.Domain.Base;
using Sixman.Chima.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sixman.Chima.Domain.Food
{
    /// <summary>
    /// 食材
    /// </summary>
    public class FoodMaterial 
        : ChiMaEntityBase
        , IDescription
    {
        public long FoodMaterialCategoryId { get; set; }
        public FoodMaterialCategory FoodMaterialCategory { get; set; }
        [Required]
        [StringLength(256)]
        ///描述
        public string Description { get; set; }
        /// <summary>
        /// 卡路里
        /// </summary>
        public int Calorie { get; set; }
        /// <summary>
        /// 蛋白质
        /// </summary>
        public int Protein { get; set; }
        /// <summary>
        /// 维生素
        /// </summary>
        public int Vitamin { get; set; }
        /// <summary>
        /// 矿物质
        /// </summary>
        public int Minerals { get; set; }
        /// <summary>
        /// 纤维素
        /// </summary>
        public int Fibrin { get; set; }
        /// <summary>
        /// 碳水化合物
        /// </summary>
        public int Carbohydrate { get; set; }
        [StringLength(50)]
        public string Season { get; set; }

        public ICollection<FoodMaterialHealthAffect> FoodMaterialHealthAffects { get; set; }

    }
}
