﻿using System;
using Castle.Facilities.Logging;
using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Collections.Extensions;
using Abp.Dependency;

namespace SixMan.ChiMa.Migrator
{
    public class Program
    {
        public static string Environment { get; private set; } = "Development";

        private static bool _skipConnVerification = false;

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Environment = args[0];
            }
            Console.WriteLine($"Environment:{Environment}");
            //Console.ReadKey();

            ParseArgs(args);

            using (var bootstrapper = AbpBootstrapper.Create<ChiMaMigratorModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                        .WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();

                using (var migrateExecuter = bootstrapper.IocManager.ResolveAsDisposable<MultiTenantMigrateExecuter>())
                {
                    migrateExecuter.Object.Run(_skipConnVerification);
                }

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                switch (arg)
                {
                    case "-s":
                        _skipConnVerification = true;
                        break;
                }
            }
        }
    }
}
