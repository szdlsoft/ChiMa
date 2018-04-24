using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SixMan.ChiMa.Domain.Configuration;
using SixMan.ChiMa.EFCore;
using SixMan.ChiMa.Migrator.DependencyInjection;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.DomainService;

namespace SixMan.ChiMa.Migrator
{
    [DependsOn(typeof(ChiMaDomainServiceModule))]
    [DependsOn(typeof(ChiMaEFCoreModule))]
    public class ChiMaMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ChiMaMigratorModule(ChiMaEFCoreModule ChiMaEFCoreModule)
        {
            ChiMaEFCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ChiMaMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ChiMaConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
