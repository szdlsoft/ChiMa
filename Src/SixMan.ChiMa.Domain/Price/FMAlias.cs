using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Price
{
    /// <summary>
    /// 食材别名库
    /// 爬虫得到得价格信息，是食材得名字，导入到系统，需要对照表
    /// </summary>
    public class FMAlias
        : ChiMaSmallEntityBase
    {
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        [Required]
        [StringLength(LengthConstants.MaxNameLength)]
        public string Name { get; set; }

    }
}
