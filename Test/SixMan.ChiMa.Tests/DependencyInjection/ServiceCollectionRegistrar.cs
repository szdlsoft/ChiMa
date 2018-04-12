using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Abp.Dependency;
using SixMan.ChiMa.EFCore;
using SixMan.ChiMa.Domain.Identity;

namespace SixMan.ChiMa.Tests.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            services.AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            //UseInmeoryDB(iocManager, serviceProvider);

            //用mysql
            UseMysql(iocManager);

        }

        private static void UseInmeoryDB(IIocManager iocManager, IServiceProvider serviceProvider)
        {
            var builder = new DbContextOptionsBuilder<ChiMaDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<ChiMaDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }

        private static void UseMysql(IIocManager iocManager)
        {
            var builder = new DbContextOptionsBuilder<ChiMaDbContext>();
            ChiMaDbContextConfigurer.Configure(builder, "Server=localhost;port=3306;database=ChiMaDb3;uid=root;password=root;character set=utf8;Old Guids=true");
            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<ChiMaDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}
