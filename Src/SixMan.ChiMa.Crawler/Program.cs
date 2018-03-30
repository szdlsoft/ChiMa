using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Castle.Facilities.Logging;
using HttpCode.Core;
using System;
using System.Linq;
using System.Text;

namespace SixMan.ChiMa.Crawler
{
    class Program
    {
        private static IIocManager iocManager;
        static void Main(string[] args)
        {
            Console.WriteLine("ChiMa Crawler start !");
            using (var bootstrapper = AbpBootstrapper.Create<ChiMaCrawlerModule>())
            {
                InitAbp(bootstrapper);
                RunTasks();
            }          

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadKey();
        }

        private static void RunTasks()
        {
            IChiMaQuartzScheduleJobManager taskManager = iocManager.Resolve<IChiMaQuartzScheduleJobManager>();

            var tasks = iocManager.ResolveAll<ICrawlerTask>();

            foreach( var task in tasks)
            {
                taskManager.ScheduleAsync(task);
            }
        }

        private static void InitAbp(AbpBootstrapper bootstrapper)
        {
            bootstrapper.IocManager.IocContainer
                .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                    .WithConfig("log4net.config")
                );

            bootstrapper.Initialize();
            iocManager = bootstrapper.IocManager;
        }   


    }
}
