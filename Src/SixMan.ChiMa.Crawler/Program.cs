using Abp;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.Domain.Repositories;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Castle.Facilities.Logging;
using HttpCode.Core;
using SixMan.ChiMa.Crawler.CrawlerTasks;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.DomainService;
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
                TestRepository();
                RunTasks();
            }          

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadKey();
        }

        private static void TestRepository()
        {
            IRepository<FoodMaterialCategory, long> _foodMaterialCategoryRepository = Resolve<IRepository<FoodMaterialCategory, long>>();
            IFoodMaterialImportManager manager = Resolve<IFoodMaterialImportManager>();
            //_foodMaterialCategoryRepository.Insert(new FoodMaterialCategory()
            //{
            //    Name = "ABC"
            //});


            //manager.ImportCategory(new FoodMaterialRawDataItem()
            //{
            //    Top = "123",
            //    Middle = "456",
            //    FoodMaterials = new FoodMaterialCollection()
            //});

            //var entity = _foodMaterialCategoryRepository.FirstOrDefault(f => f.Name == "123");

            //_foodMaterialCategoryRepository.Delete(entity);
        }

        private static T Resolve<T>()
        {
            return iocManager.Resolve<T>();
        }

        private static  void RunTasks()
        {
            IChiMaQuartzScheduleJobManager taskManager = iocManager.Resolve<IChiMaQuartzScheduleJobManager>();

            var tasks = iocManager.ResolveAll<ICrawlerTask>();

            foreach (var task in tasks)
            {
                taskManager.ScheduleAsync(task);
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

            bootstrapper.Initialize();
            iocManager = bootstrapper.IocManager;
        }   


    }
}
