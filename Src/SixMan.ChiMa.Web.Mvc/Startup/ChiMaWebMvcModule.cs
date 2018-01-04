using Abp.Modules;
using Abp.Reflection.Extensions;
using SixMan.ChiMa.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SixMan.ChiMa.Web.Startup
{
    [DependsOn(typeof(ChiMaWebCoreModule))]
    public class ChiMaWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ChiMaWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<ChiMaNavigationProvider>();

            //Configuration.Modules.AbpMvc();
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ChiMaWebMvcModule).GetAssembly());
        }
    }
}