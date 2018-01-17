using Abp.AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    [AutoMap(typeof(Purchase))]
    public class PurchaseDto
        : MobileBaseDto
    {
        
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? PurchaseTime { get; set; }
        /// <summary>
        /// 制作时间
        /// </summary>
        public DateTime? MakeTime { get; set; }
        /// <summary>
        /// 食材
        /// </summary>
        public FoodMaterial FoodMaterial { get; set; }
        /// <summary>
        /// 采购量 
        /// </summary>
        public int? Volume { get; set; }
        /// <summary>
        /// 是否已经采购
        /// </summary>
        public bool HasPurchased { get; set; }
    }
}
