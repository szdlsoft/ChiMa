using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using SixMan.ChiMa.Authentication.JwtBearer;
using SixMan.ChiMa.Configuration;
using SixMan.ChiMa.Domain.Identity;
using SixMan.ChiMa.Web.Resources;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using SixMan.ChiMa.Web.Resources.Startup;
using Abp.AspNetCore.Mvc.Results.Wrapping;
using Castle.MicroKernel.Registration;

#if FEATURE_SIGNALR
using Owin;
using Abp.Owin;
using SixMan.ChiMa.Owin;
#endif

namespace SixMan.ChiMa.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //MVC
            services.AddMvc(options =>
            {
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                
            });

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddCloudscribePagination();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "ChiMa API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.OperationFilter<AddAuthTokenHeaderParameter>();
                options.OrderActionsBy(ad => ad.RelativePath);
            });

            //Configure Abp and Dependency Injection
            return services.AddAbp<ChiMaWebMvcModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
                // 替换 IAbpActionResultWrapperFactory
                options.IocManager.IocContainer.Register(Component.For<IAbpActionResultWrapperFactory>()
                    .ImplementedBy<NullAbpActionResultWrapperFactory>().LifestyleSingleton().IsDefault());
            });

 


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); //Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            

#if FEATURE_SIGNALR
            //Integrate to OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#endif

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "category", "Category/{category}/{action=Index}/{id?}",
                    defaults:new {controller= "Category" }
                    );
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            //Enable middleware to serve swagger - ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ChiMa API V1");
            }); //URL: /swagger 
        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "ChiMa";

            app.UseAbp();

            app.MapSignalR();
        }
#endif
    }
}
