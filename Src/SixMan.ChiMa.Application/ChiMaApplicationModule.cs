using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SixMan.ChiMa.Application.Authorization;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Authorization;

namespace SixMan.ChiMa.Application
{
    [DependsOn(
        typeof(ChiMaDomainModule), 
        typeof(AbpAutoMapperModule))]
    public class SixManApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ChiMaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SixManApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}
