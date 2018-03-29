using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Food
{
    /// <summary>
    /// 食材健康影响
    /// </summary>
    public class FoodMaterialHealthAffect
        : ChiMaEntityBase
        , IAffectDegree
    {
        public FoodMaterial FoodMaterial { get; set; }
        public HealthConcern HealthConcern { get; set; }
        /// <summary>
        /// 影响程度
        /// </summary>
        public int AffectDegree { get; set; }
    }
}
