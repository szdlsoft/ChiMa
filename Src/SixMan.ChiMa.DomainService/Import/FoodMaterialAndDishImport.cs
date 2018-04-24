using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class FoodMaterialAndDishImport
        : IFoodMaterialAndDishImport
    {
        ICrawlerDataStore _foodMaterialStore;
        ICrawlerDataStore _dishDetailsFileStore;

        FoodMaterialManager _foodMaterialManager;
        DishManager _dishManager;
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
            }

            //菜品及其相关
            foreach (var dishRawData in _dishDetailsFileStore.GetAll<DishDetailsRawDataItem>())
            {
                _dishManager.Import(dishRawData);
            }
        }
  
    }
}
