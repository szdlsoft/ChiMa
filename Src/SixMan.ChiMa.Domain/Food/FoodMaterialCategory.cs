﻿using Abp.Domain.Entities.Auditing;
using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SixMan.ChiMa.Domain.Food
{
    /// <summary>
    /// 食材分类
    /// </summary>
    public class FoodMaterialCategory : CategoryBase
    {
        /// <summary>
        /// 父节点
        /// </summary>
        [ForeignKey("ParentId")]
        public FoodMaterialCategory Parent { get; set; }
        public long? ParentId { get; set; }
        /// <summary>
        /// 分类索引号 
        /// </summary>
        public int? IndexNo { get; set; }

        public List<FoodMaterialCategory> Childern { get; set; }

        public FoodMaterialCategory() : base()
        {

        }
    }
}
