using Abp.Domain.Uow;
using Abp.Quartz;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using Quartz;
using SixMan.ChiMa.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    public class MeiShiChinaCrawler
         : JobBase
         , ICrawlerTask
    {
        public Type TaskType => typeof(MeiShiChinaCrawler);

        public IFoodMaterialImport importer { get; set; }

        FoodMaterialRawData rawData;

        public MeiShiChinaCrawler()
                    :base()
        {
            importer = NullFoodMaterialImport.Instance;
        }

        public void ConfigureJob(JobBuilder job)
        {
            job.WithIdentity("美食天下", "食材菜谱")
                                         .WithDescription("美食天下");
        }

        public void ConfigureTrigger(TriggerBuilder trigger)
        {
            trigger.StartNow()
            .WithSimpleSchedule(schedule =>
            {
                schedule.RepeatForever()
                    .WithIntervalInSeconds(600)
                    .Build();
            });
        }


        [UnitOfWork]
        public override async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //var publishTime = priceManager.GetLatest(Area);
                Console.WriteLine("开始 美食天下的食材菜谱。。。。");
                await ExecuteImp(context);
                Console.WriteLine("结束 爬美食天下的食材菜谱  ");
            }
            catch (Exception ex)
            {
                //Logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private async Task ExecuteImp(IJobExecutionContext context)
        {
            rawData = new FoodMaterialRawData();
            IHtmlDocument doc = await CrawlerHelper.GetDocument( " http://www.meishichina.com/YuanLiao/");

            var lis = doc.QuerySelectorAll(".nav_wrap2 li a"); // 找出价格行

            Logger.Info($"找到食材顶级分类: {lis.Length -2} 个");

            for( int i =1; i <= lis.Length-2; i++) // 去掉一头一尾
            {
                await ImportTopCategory(lis[i]);
            }

            importer.Import(rawData);
            Logger.Info($"共有{rawData.TopCount} 个大类 {rawData.MiddleCount} 个中类 {rawData.MaterialCount} 个食材 ");

        }

        private async Task ImportTopCategory(IElement element)
        {
            var topCatName = element.InnerHtml;
            var topCatUrl = element.GetAttribute("href");
            Logger.Info($"导入食材顶级分类: {topCatName} {topCatUrl}");

            //var url = $"http:{topCatUrl}";
            var topDoc = await CrawlerHelper.GetDocumentAddHttpPrefix(topCatUrl);

            var middleDivs = topDoc.QuerySelectorAll(".category_sub.clear");
            Logger.Info($"   有{middleDivs.Length} 中类 ");

            foreach( var midDiv in middleDivs)
            {
                var middleName = midDiv.FirstElementChild.TextContent; //h2 // node 是可视树， element 是逻辑树
                var ul = midDiv.LastElementChild;  //ul

                var foodMaterials = new FoodMaterialCollection();
                foreach ( var li in ul.GetElementsByTagName("li"))
                {
                    var a = li.FirstElementChild;
                    var foodMaterialName = a.TextContent;
                    var foodMaterialHref = a.GetAttribute("href");

                    foodMaterials.Add(await GetFoodMaterial(foodMaterialName, foodMaterialHref));                   
                }
                Logger.Info($"    {middleName} 有{foodMaterials.Count}个食材 ");

                var rawItem = new FoodMaterialRawDataItem()
                {
                    Top = topCatName,
                    Middle = middleName,
                    FoodMaterials = foodMaterials
                };

                rawData.Add(rawItem);

                //Logger.Info(sb.ToString());
            }


        }

        private async Task<FooMaterialItem> GetFoodMaterial(string foodMaterialName, string foodMaterialHref)
        {
            string englishName = CrawlerHelper.GetUrlLast(foodMaterialHref);

            var foodMaterial = new FooMaterialItem()
            {
                Name = foodMaterialName,
                EnglishName = englishName,
                SourceUrl = foodMaterialHref,
                ImagePath = "FoodMaterial\\" + englishName + ".bmp"
            };

            IHtmlDocument foodMaterialDoc = await CrawlerHelper.GetDocumentAddHttpPrefix(foodMaterialHref + "/useful");

            var sourceImgUrl = foodMaterialDoc.QuerySelector("#category_pic").GetAttribute("data-src");
            await CrawlerHelper.GetImgAndSave(sourceImgUrl, foodMaterial.ImagePath);

            var nutritionsUL = foodMaterialDoc.QuerySelector("category_use_table.mt10.clear")?.FirstElementChild;
            foodMaterial.Nutritions = new List<string>();
            if( nutritionsUL != null)
            {
                foreach (var li in nutritionsUL.GetElementsByTagName("li"))
                {
                    var name = li.TextContent;
                    var value = li.FirstElementChild.TextContent;
                    foodMaterial.Nutritions.Add($"{name} {value}");                
                }
            }

            return foodMaterial;
        }

       
    }
}
