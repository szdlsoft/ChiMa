using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Configuration;
using SixMan.ChiMa.Domain.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    [DependsOn(typeof(Abp.AutoMapper.AbpAutoMapperModule))]
    [DependsOn(typeof(ChiMaDomainModule))]
    public  class ChiMaDomainServiceModule
        : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ChiMaDomainServiceModule()
        {
            _appConfiguration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        }

        public override void PreInitialize()
        {
            CrawlerConfig.Load(_appConfiguration);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaDomainServiceModule).GetAssembly());
        }
    }
}
