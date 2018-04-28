using System;
using Castle.MicroKernel.Registration;
using NSubstitute;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Configuration.Startup;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Abp.Zero.EntityFrameworkCore;
using SixMan.ChiMa.EFCore;
using SixMan.ChiMa.Tests.DependencyInjection;
using SixMan.ChiMa.Application;
using SixMan.ChiMa.DomainService;
using SixMan.ChiMa.MonyunSms;

namespace SixMan.ChiMa.Tests
{
    [DependsOn(
        typeof(ChiMaApplicationModule),
        typeof(ChiMaDomainServiceModule),
        typeof(ChiMaEFCoreModule),
        typeof(AbpTestBaseModule),
        typeof(ChiMaMonyunSmsModule)
        )]
    public class ChiMaTestModule : AbpModule
    {
        public ChiMaTestModule(ChiMaEFCoreModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
            //用内存数据库？
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            // Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator<ChiMaDbContext>>();

            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}
