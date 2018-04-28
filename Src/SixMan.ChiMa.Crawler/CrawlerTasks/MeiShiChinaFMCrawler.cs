using Abp;
using Abp.Domain.Uow;
using Abp.Quartz;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using HttpCode.Core;
using Quartz;
using SixMan.ChiMa.Domain;
using SixMan.ChiMa.Domain.Food;
using SixMan.ChiMa.DomainService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Crawler.CrawlerTasks
{
    public class MeiShiChinaFMCrawler
         : JobBase
         , ICrawlerTask
    {
        public Type TaskType => typeof(MeiShiChinaFMCrawler);

        public IFoodMaterialDataStore dataStore { get; set; }

        public string Name => "MeiShiChinaFM";

        FoodMaterialRawData rawData;

        public MeiShiChinaFMCrawler()
                    :base()
        {
            dataStore = NullFoodMaterialDataStore.Instance;
        }

        public void ConfigureJob(JobBuilder job)
        {
            job.WithIdentity("美食天下", "食材")
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


        //[UnitOfWork]
        public override async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //var publishTime = priceManager.GetLatest(Area);
                Console.WriteLine("开始 美食天下的食材菜谱。。。。");
                var startTime = DateTime.Now;
                await ExecuteImp(context);
                Console.WriteLine("结束 爬美食天下的食材菜谱  ");
                Logger.Info($"导入美食天下的食材菜谱总耗时：{DateTime.Now.Subtract(startTime).TotalSeconds}");
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
            IHtmlDocument doc = await CrawlerHelper.GetDocumentASync( " http://www.meishichina.com/YuanLiao/");

            var lis = doc.QuerySelectorAll(".nav_wrap2 li a"); // 找出价格行

            Logger.Info($"找到食材顶级分类: {lis.Length -2} 个");

            for( int i =1; i <= lis.Length-2; i++) // 去掉一头一尾
            {
                await ImportTopCategoryAsync(lis[i]);
                //break;

            }

            //importer.Import(rawData);
            Logger.Info($"共有{rawData.TopCount} 个大类 {rawData.MiddleCount} 个中类 {rawData.MaterialCount} 个食材 ");

        }

        private async Task ImportTopCategoryAsync(IElement element)
        {
            var startTime = DateTime.Now;

            var topCatName = element.InnerHtml;
            var topCatUrl = element.GetAttribute("href");
            Logger.Info($"导入食材顶级分类: {topCatName} {topCatUrl}");

            //var url = $"http:{topCatUrl}";
            var topDoc = await CrawlerHelper.GetDocumentAddHttpPrefixAsync(topCatUrl);

            var middleDivs = topDoc.QuerySelectorAll(".category_sub.clear");
            Logger.Info($"   有{middleDivs.Length} 中类 ");

            foreach( var midDiv in middleDivs)
            {
                var middleCatName = midDiv.FirstElementChild.TextContent; //h2 // node 是可视树，用xpath， element 是逻辑树,用selector
                if(dataStore.HasSave(topCatName, middleCatName))
                {
                    continue; // 已经导入的，就不重复导入
                }

                var ul = midDiv.LastElementChild;  //ul
                var foodMaterials = new FoodMaterialCollection();
                foreach (var li in ul.GetElementsByTagName("li"))
                {
                    var a = li.FirstElementChild;
                    var foodMaterialName = a.TextContent;
                    var foodMaterialHref = a.GetAttribute("href");

                    var foodMaterial = await TryGetFoodMaterial(foodMaterialName, foodMaterialHref);
                    if (foodMaterial != null)
                    {
                        foodMaterials.Add(foodMaterial);

                    }
                }
                Logger.Info($"    {middleCatName} 有{foodMaterials.Count}个食材 ");

                var rawItem = new FoodMaterialRawDataItem()
                {
                    Top = topCatName,
                    Middle = middleCatName,
                    FoodMaterials = foodMaterials
                };

                dataStore.SaveCategory(rawItem);

                rawData.Add(rawItem);

                string msg = $"导入{topCatName} {middleCatName}耗时：{DateTime.Now.Subtract(startTime).TotalSeconds}";
                Console.WriteLine(msg);
                Logger.Info(msg);
                //break;
            }

        }

        private async Task<FoodMaterialItem> TryGetFoodMaterial(string foodMaterialName, string foodMaterialHref)
        {
            try
            {
                return await GetFoodMaterial(foodMaterialName, foodMaterialHref);
            }
            catch( Exception ex)
            {
                Logger.Debug($"导入{foodMaterialName} {foodMaterialHref} " + ex.Message);
            }

            return null;
        }

        private async Task<FoodMaterialItem> GetFoodMaterial(string foodMaterialName, string foodMaterialHref)
        {
            string englishName = CrawlerHelper.GetUrlLast(foodMaterialHref);

            var foodMaterial = new FoodMaterialItem()
            {
                Description = foodMaterialName,
                EnglishName = englishName,
                SourceUrl = foodMaterialHref,
                Photo = FoodMaterial.GetImageUrlPath(englishName),
            };

            IHtmlDocument foodMaterialDoc = await CrawlerHelper.GetDocumentAddHttpPrefixAsync(foodMaterialHref + "/useful");

            var sourceImgUrl = foodMaterialDoc.QuerySelector("#category_pic")?.GetAttribute("data-src");
            if( sourceImgUrl == null)
            {
                Logger.Error($"{foodMaterialName} 找不到 category_pic");
            }

            //string localImgPath = "FoodMaterial\\" + englishName + ".jpg";
            if(ChiMaConfig.NeedDownloadFoodMaterialImage && sourceImgUrl != null)
            {
                string localImgPath = FoodMaterial.GetImageLocalPath(englishName);
                CrawlerHelper.DownloadImgAndSaveAsync(sourceImgUrl, localImgPath);
            }

            var nutritionsUL = foodMaterialDoc.QuerySelector(".category_use_table.mt10.clear")?.FirstElementChild;
            foodMaterial.Nutritions = new List<string>();
            if( nutritionsUL != null)
            {
                foreach (var li in nutritionsUL.GetElementsByTagName("li"))
                {
                    var name = li.TextContent;
                    //var value = li.FirstElementChild.TextContent;
                    foodMaterial.Nutritions.Add(name);                
                }
            }

            return foodMaterial;
        }

        public bool OnlyOneTime => true;
    }
}
