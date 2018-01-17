using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using SixMan.ChiMa.Authentication.JwtBearer;
using SixMan.ChiMa.Configuration;
using SixMan.ChiMa.EFCore;
using SixMan.ChiMa.Application;
using SixMan.ChiMa.Domain;
using System.Linq;

#if FEATURE_SIGNALR
using Abp.Web.SignalR;
#endif

namespace SixMan.ChiMa
{
    [DependsOn(
         typeof(ChiMaApplicationModule),
        typeof(ChiMaMobApplicationModule),
         typeof(ChiMaEFCoreModule),
         typeof(AbpAspNetCoreModule)
#if FEATURE_SIGNALR 
        ,typeof(AbpWebSignalRModule)
#endif
     )]
    public class ChiMaWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ChiMaWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ChiMaConsts.ConnectionStringName
            );

            // Use database for language management
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(ChiMaApplicationModule).GetAssembly(),
                     useConventionalHttpVerbs: true
                 )
                 //.Where( IsNotMoile )
                 //.WithConventionalVerbs()
                 ;
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(ChiMaMobApplicationModule).GetAssembly(),
                     useConventionalHttpVerbs: true,
                     moduleName: "mob"
                 )
                 //.Where(IsMoile)
                 //.WithConventionalVerbs()
                 ;
            //Configuration.Modules.AbpMvc();

            ConfigureTokenAuth();
        }

        bool IsMoile(Type type)
        {
            bool result = type.GetInterfaces().Any(i => i == typeof( IMobileAppService));
            return result;
        }

        bool IsNotMoile(Type type)
        {
            bool result = type.GetInterfaces().Any(i => i == typeof(IMobileAppService));
            return !result;
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaWebCoreModule).GetAssembly());
        }
    }
}
