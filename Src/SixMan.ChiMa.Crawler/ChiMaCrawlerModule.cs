using Abp.Modules;
using Abp.Quartz;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using SixMan.ChiMa.Application;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Configuration;
using SixMan.ChiMa.Domain.Web;
using SixMan.ChiMa.DomainService;
using SixMan.ChiMa.EFCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    [DependsOn(typeof(ChiMaDomainServiceModule))]
    [DependsOn(typeof(ChiMaEFCoreModule))]
    [DependsOn(typeof(ChiMaApplicationModule))]
    [DependsOn(typeof(AbpQuartzModule))]
    public class ChiMaCrawlerModule
        : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ChiMaCrawlerModule(ChiMaEFCoreModule ChiMaEFCoreModule)
        {
            //ChiMaEFCoreModule.SkipDbSeed = true;

            //_appConfiguration = AppConfigurations.Get(
            //    typeof(ChiMaCrawlerModule).GetAssembly().GetDirectoryPathOrNull()
            //);

            // 就读哥数据库连接，没啥意义！
            //_appConfiguration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            _appConfiguration = AppConfigurations.GetWebConfigByEnviroment(Program.Environment);

        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ChiMaConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            ChiMaConfig.Load(_appConfiguration);
        }

        public override void Initialize()
        {
            IocManager.IocContainer.Register(
                Classes.FromAssembly(typeof(ChiMaCrawlerModule).GetAssembly())
                    .BasedOn<ICrawlerTask>()
                    .WithService.Self()
                    .WithService.Select(new Type[] { typeof(ICrawlerTask) })
                    .LifestyleSingleton()
                );

            IocManager.RegisterAssemblyByConvention(typeof(ChiMaCrawlerModule).GetAssembly());

        }
    }
}
