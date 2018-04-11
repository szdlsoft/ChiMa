using Abp.Quartz;
using Quartz;
using SixMan.ChiMa.DomainService.Price;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler
{
    public abstract class PriceCrawlerBase
        : JobBase
    {
        public IPriceManager priceManager { get; set; }
       


    }
}
