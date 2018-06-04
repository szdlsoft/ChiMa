using System;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.EFCore.Seed;

namespace SixMan.ChiMa.EFCore
{
    [DependsOn(
        typeof(ChiMaDomainModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class ChiMaEFCoreModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ChiMaDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ChiMaDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        ChiMaDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }

                    //options.DbContextOptions.UseLoggerFactory(MyLoggerFactory);
                });
            }

            AddUnitOfWorkFilters();
        }

        private void AddUnitOfWorkFilters()
        {
            Configuration.UnitOfWork.RegisterFilter(ChimaDataFilter.FamillyDataFilter, false);
        }

        /// <summary>
        /// 显示sql
        /// </summary>
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                        || category == DbLoggerCategory.Query.Name, true)
            });

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaEFCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if ( //false && 
                !SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
