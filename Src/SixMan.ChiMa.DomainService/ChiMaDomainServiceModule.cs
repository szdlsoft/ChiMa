using Abp.Modules;
using Abp.Reflection.Extensions;
using SixMan.ChiMa.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    [DependsOn(typeof(ChiMaDomainModule))]
    public  class ChiMaDomainServiceModule
        : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaDomainServiceModule).GetAssembly());
        }
    }
}
