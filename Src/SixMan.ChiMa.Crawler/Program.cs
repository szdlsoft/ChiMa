using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Castle.Facilities.Logging;
using System;

namespace SixMan.ChiMa.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ChiMa Crawler start !");
            using (var bootstrapper = AbpBootstrapper.Create<ChiMaCrawlerModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                        .WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
