using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.Domain.Repositories;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Castle.Facilities.Logging;
using HttpCode.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.PlatformAbstractions;
using SixMan.ChiMa.Crawler.CrawlerTasks;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.DomainService;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    public class Program
    {
        public static string Environment { get; private set; } = "Development";

        private static IIocManager iocManager;
        static void Main(string[] args)
        {
            //var hostBuilder = new HostBuilder();
            if( args.Length > 0)
            {
                Environment = args[0];
            }
            Console.WriteLine($"Environment:{Environment}");
            Console.ReadKey();

            Console.WriteLine("ChiMa Crawler start !");
            using (var bootstrapper = AbpBootstrapper.Create<ChiMaCrawlerModule>())
            {
                InitAbp(bootstrapper);
                RunTasks();
            }          

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadKey();
        }

        

        private static T Resolve<T>()
        {
            return iocManager.Resolve<T>();
        }

        private static async  void RunTasks()
        {
            IChiMaQuartzScheduleJobManager taskManager = iocManager.Resolve<IChiMaQuartzScheduleJobManager>();

            var tasks = iocManager.ResolveAll<ICrawlerTask>();

            foreach (var task in tasks)
            {
                if (CrawlerConfig.GetTaskEnabled(task.Name))
                {
                    if( task.OnlyOneTime )
                    {
                        await task.Execute(null);
                    }
                    else
                    {
                        await taskManager.ScheduleAsync(task);
                    }
                }

            }

            //var task = Resolve<MeiShiChinaCrawler>();
            // task.Execute(null);

        }

        private static void InitAbp(AbpBootstrapper bootstrapper)
        {
            bootstrapper.IocManager.IocContainer
                .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                    .WithConfig("log4net.config")
                );
            // 可以注入 _appConfiguration

            bootstrapper.Initialize();
            iocManager = bootstrapper.IocManager;
        }   


    }
}
