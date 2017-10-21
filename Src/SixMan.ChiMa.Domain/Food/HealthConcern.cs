using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Food
{
    /// <summary>
    /// 健康关注
    /// </summary>
    public class HealthConcern 
        : ChiMaEntityBase
        , IDescription
    {
        public long HealthConcernCategoryId { get; set; }
        public HealthConcernCategory HealthConcernCategory { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public ICollection<FoodMaterialHealthAffect> FoodMaterialHealthAffects { get; set; }
    }
}
