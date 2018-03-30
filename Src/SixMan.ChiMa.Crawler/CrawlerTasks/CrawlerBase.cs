﻿using Abp.Quartz;
using Quartz;
using SixMan.ChiMa.DomainService.Price;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    public abstract class CrawlerBase
        : JobBase
    {
        public IPriceManager priceManager { get; set; }
       


    }
}