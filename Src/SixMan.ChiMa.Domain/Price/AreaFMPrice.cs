using SixMan.ChiMa.Domain.Base;
using SixMan.ChiMa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Domain.Price
{
    /// <summary>
    /// 地区食材报价
    /// </summary>
    public class AreaFMPrice
         : ChiMaLargeEntityBase
    { 
        /// <summary>
        /// 报价地区
        /// </summary>
        public Area Area { get; set; }
        /// <summary>
        /// 发布信息时间
        /// </summary>
        public DateTime PublishTime { get; set; }

        public ICollection<FMPriceItem> FMPriceItems { get; set; }
    }
}
