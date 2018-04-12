using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SixMan.ChiMa.DomainService
{
    //[UnitOfWork(false)]
    public class FoodMaterialImportManager
        : IFoodMaterialImportManager
        , Abp.Dependency.ISingletonDependency
    {
        public IRepository<FoodMaterialCategory, long> FoodMaterialCategoryRepository { get; set; }
        public IRepository<FoodMaterial, long> FoodMaterialRepository { get; set; }
        public IRepository<Nutrition> NutritionRepository { get; set; }
        public IRepository<FoodMaterialNutrition> FoodMaterialNutritionRepository { get; set; }

        public IUnitOfWork unitOfWork { get; set; }

        public bool HasImport(string topCatName, string middleCatName)
        {
            return FoodMaterialCategoryRepository.Count(  c => c.Name == middleCatName ) > 0;
        }

        public void Import(FoodMaterialRawData rawData)
        {
            foreach( var item in rawData)
            {
                ImportCategory(item);
            }
        }

        [UnitOfWork]
        public void ImportCategory(FoodMaterialRawDataItem item)
        {
            //unitOfWork.Options.IsTransactional = false;

            FoodMaterialCategory cat = GetOrCreateCategory(item);
            foreach( var food in item.FoodMaterials)
            {
                ImportFoodMaterial(cat, food);
            }
        }

        private FoodMaterialCategory GetOrCreateCategory(FoodMaterialRawDataItem item)
        {
            var top = FoodMaterialCategoryRepository.FirstOrDefault( c => c.Name == item.Top );
            if( top == null)
            {
                top = FoodMaterialCategoryRepository.Insert(new FoodMaterialCategory()
                {
                    Name = item.Top,
                });

                //top = FoodMaterialCategoryRepository.Get(top.Id);

                //var top2 = FoodMaterialCategoryRepository.FirstOrDefault(c => c.Name == item.Top);
                //var top3 = top2;
            }
            var middle = FoodMaterialCategoryRepository.FirstOrDefault(c => c.Name == item.Middle);
            if( middle == null)
            {
                middle = FoodMaterialCategoryRepository.Insert(new FoodMaterialCategory()
                {
                    Name = item.Middle,
                    Parent = top,
                });
            }
            return middle;
        }

        private void ImportFoodMaterial(FoodMaterialCategory cat, FoodMaterialItem food)
        {
            FoodMaterial fm = Mapper.Map<FoodMaterial>(food);
            fm.FoodMaterialCategory = cat;

            fm = FoodMaterialRepository.Insert(fm);

            foreach( var t in food.Nutritions)
            {
                ImportNutrition(fm, t);
            }

        }
        static Regex nutritionRegex = new Regex(@"(?<name>\w+)\((?<unit>\w+)\)\s*\((?<content>\w+)\)");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fm"></param>
        /// <param name="t">热量(大卡) (395)  </param>
        private void ImportNutrition(FoodMaterial fm, string t)
        {
            var matches = nutritionRegex.Match(t).Groups;
            if( matches.Count != 4)
            {
                return;
            }
            var name = matches["name"].Value;
            var unit = matches["unit"].Value;
            double content = 0;
            double.TryParse( matches["content"].Value, out content);

            Nutrition nut = GetOrCreateNutrition(name, unit);

            FoodMaterialNutritionRepository.Insert(new FoodMaterialNutrition()
            {
                Nutrition = nut,
                FoodMaterial = fm,
                Content = content
            });
        }

        private Nutrition GetOrCreateNutrition(string name, string unit)
        {
            var entity = NutritionRepository.FirstOrDefault(c => c.Name == name
                                                               && c.Unit == unit);
            if (entity == null)
            {
                entity = NutritionRepository.Insert(new Nutrition()
                {
                    Name = name,
                    Unit = unit,
                });
            }

            return entity;
        }
    }
}
