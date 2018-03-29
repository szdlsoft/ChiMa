using Abp.Modules;
using Abp.Reflection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    public class ChiMaCrawlerModule
        : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaCrawlerModule).GetAssembly());
        }
    }
}
