﻿using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Price
{
    /// <summary>
    /// 食材价格
    /// </summary>
    public class FMPriceItem
        : ChiMaLargeEntityBase
    {
        public AreaFMPrice AreaFMPrice { get; set; }
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required]
        [StringLength(LengthConstants.MaxNameLength)]
        public string Unit { get; set; }
    }
}
