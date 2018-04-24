using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.DomainService
{
    public class FoodMaterialAndDishImport
        : IFoodMaterialAndDishImport
    {
        ICrawlerDataStore _foodMaterialStore;
        ICrawlerDataStore _dishDetailsFileStore;

        FoodMaterialManager _foodMaterialManager;
        DishManager _dishManager;

        public ILogger Logger { get; set; }
        public FoodMaterialAndDishImport(ICrawlerDataStoreFactory crawlerDataStoreBFactory,
                                        FoodMaterialManager foodMaterialManager,
                                         DishManager dishManager)
        {
            _foodMaterialStore = crawlerDataStoreBFactory.Create("FoodMaterial");
            _dishDetailsFileStore = crawlerDataStoreBFactory.Create("DishDetails");
            _foodMaterialManager = foodMaterialManager;
            _dishManager = dishManager;
        }

        public void Execute()
        {            
            //食材及其分类
            foreach( var fmRawData in _foodMaterialStore.GetAll<FoodMaterialRawDataItem>())
            {
                _foodMaterialManager.Import(fmRawData);
                Console.WriteLine($"食材：{fmRawData.Top}_{fmRawData.Middle} 成功");
            }

            //菜品及其相关
            //太多了，是否考虑并发！
            var dishCatDetails = new DishListRawData(_dishDetailsFileStore.GetAll<DishDetailsRawData>());
            IEnumerable<DishDetailsRawDataItem> dishs = dishCatDetails.GetDishs();
            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 100,
            };

            var start = DateTime.Now;
            ShowAndLog($"导入菜品 start:{start}");
           Parallel.ForEach(dishs, parallelOptions, dish =>
            {
                try
                {
                    _dishManager.Import(dish);
                    Console.Write($".");
                }
                catch(Exception ex)
                {
                    ShowAndLog($"{dish.ToString()} {ex.Message} {ex.InnerException?.Message}");
                }
            });
            var end = DateTime.Now;
            ShowAndLog($"导入菜品 end:{end} 耗时:{end.Subtract(start).TotalMinutes}");
        }

        private void ShowAndLog(string msg)
        {
            Console.WriteLine(msg);
            Logger.Info(msg);
        }

    }
}
