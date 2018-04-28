using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
//using SixMan.ChiMa.Application.Authorization;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Authorization;
using SixMan.ChiMa.DomainService;
using SixMan.ChiMa.MonyunSms;

namespace SixMan.ChiMa.Application
{
    [DependsOn(
        typeof(ChiMaDomainModule), 
        typeof(AbpAutoMapperModule),
        typeof(ChiMaDomainServiceModule),
        typeof(ChiMaMonyunSmsModule)
        )]
    public class ChiMaMobApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            var t = 1;// 测试
            t++;
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ChiMaMobApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}
