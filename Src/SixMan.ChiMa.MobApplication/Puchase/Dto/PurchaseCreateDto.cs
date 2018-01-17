using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public class PurchaseCreateDto
    {
        public long FoodMaterialId { get; set; }
        public DateTime? PurchaseTime { get; set; }
        public int? Volume { get; set; }
    }
}
