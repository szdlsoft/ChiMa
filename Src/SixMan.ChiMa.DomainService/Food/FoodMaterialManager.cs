using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using AutoMapper;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SixMan.ChiMa.DomainService
{
    //[UnitOfWork(false)]
    public class FoodMaterialManager
        :IDomainService
    {
        public IRepository<FoodMaterialCategory, long> FoodMaterialCategoryRepository { get; set; }
        public IRepository<FoodMaterial, long> FoodMaterialRepository { get; set; }
        public IRepository<Nutrition> NutritionRepository { get; set; }
        public IRepository<FoodMaterialNutrition> FoodMaterialNutritionRepository { get; set; }

        public IUnitOfWork unitOfWork { get; set; }

        private bool HasImport(FoodMaterialRawDataItem item)
        {
            return FoodMaterialCategoryRepository.Count(  c => c.Name == item.Middle ) > 0;
        } 
        
        public void Import(FoodMaterialRawDataItem item)
        {
            if( HasImport(item)) //不重复导入
            {
                return;
            }

            FoodMaterialCategory cat = ImportOnlyCategorys(item.Top, item.Middle);
            ImportOnlyNutritions(item.FoodMaterials.SelectMany(f => f.Nutritions).Distinct().ToList());

            foreach (var fm in item.FoodMaterials)
            {
                SaveFoodMaterials(fm, cat);
            }
        }       

        [UnitOfWork]
        public virtual void ImportOnlyNutritions(IEnumerable<string> nutritions)
        {
            List<Tuple<string, string>> nuts = new List<Tuple<string, string>>();
            foreach( var nutrition in nutritions)
            {
                ParseNutrition(nutrition, out string name, out string unit);
                if( ! nuts.Exists( item=> item.Item1 == name && item.Item2 == unit))
                {
                    nuts.Add(new Tuple<string, string>(name, unit));  //去重复
                }
            }

            foreach( var nut in nuts)
            {
                SaveNutrition(nut.Item1, nut.Item2);
            }
        }

        private void ParseNutrition(string nutrition, out string name, out string unit)
        {
            var matches = nutritionRegex.Match(nutrition).Groups;
            name = matches["name"].Value;
            unit = matches["unit"].Value;
            if(string.IsNullOrEmpty(name))
            {
                name = nutrition; //如正则没解析成功，则copy全串
            }
        }

        [UnitOfWork]
        public virtual FoodMaterialCategory ImportOnlyCategorys(string topStr, string middleStr)
        {
            var top = FoodMaterialCategoryRepository.FirstOrDefault(c => c.Name == topStr);
            if (top == null)
            {
                top = FoodMaterialCategoryRepository.Insert(new FoodMaterialCategory()
                {
                    Name = topStr,
                });
            }
            var middle = FoodMaterialCategoryRepository.FirstOrDefault(c => c.Name == middleStr);
            if (middle == null)
            {
                middle = FoodMaterialCategoryRepository.Insert(new FoodMaterialCategory()
                {
                    Name = middleStr,
                    Parent = top,
                });
            }

            return middle;
        }       

        [UnitOfWork]
        public virtual void SaveFoodMaterials( FoodMaterialItem food,FoodMaterialCategory cat)
        {
            FoodMaterial fm = Mapper.Map<FoodMaterial>(food);
            fm.FoodMaterialCategory = GetCategory(cat.Name); ;

            fm = FoodMaterialRepository.Insert(fm);

            foreach( var t in food.Nutritions)
            {
                ImportNutrition(fm, t);
            }

        }

        private FoodMaterialCategory GetCategory(string name)
        {
            return FoodMaterialCategoryRepository.FirstOrDefault(c => c.Name == name); ;
        }

        static Regex nutritionRegex = new Regex(@"(?<name>\w+)\((?<unit>\w+)\)\s*\((?<content>[\d\.]+)\)");
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

            Nutrition nut = GetNutrition(name, unit);

            FoodMaterialNutritionRepository.Insert(new FoodMaterialNutrition()
            {
                Nutrition = nut,
                FoodMaterial = fm,
                Content = content
            });
        }

        private Nutrition GetNutrition(string name, string unit)
        {
            return NutritionRepository.FirstOrDefault(c => c.Name == name
                                                               && c.Unit == unit);
        }

        private void SaveNutrition(string name, string unit)
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
        }
    }
}
