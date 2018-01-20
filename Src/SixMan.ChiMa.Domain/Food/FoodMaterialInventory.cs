using SixMan.ChiMa.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SixMan.ChiMa.Domain.Food
{
    public class FoodMaterialInventory
        : ChiMaEntityBase
        , IHaveFamilyId
    {
        public long FamilyId { get; set; }
        /// <summary>
        /// 家庭
        /// </summary>
        public SixMan.ChiMa.Domain.Family.Family Family { get; set; }
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int? Inventory { get; set; }
        
    }
}
