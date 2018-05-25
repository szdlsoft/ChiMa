using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Extensions;
using SixMan.ChiMa.Domain.Food;
using SixMan.UICommon.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SixMan.ChiMa.DomainService
{
    public class DishManager
        : IDomainService
    {
        IRepository<Dish, long> _dishRepository;
        IRepository<FoodMaterial, long> _foodMaterialRepository;
        public DishManager(IRepository<Dish, long> dishRepository,
                           IRepository<FoodMaterial, long> foodMaterialRepository)
        {
            _dishRepository = dishRepository;
            _foodMaterialRepository = foodMaterialRepository;
        }
        [UnitOfWork]
        internal void Import(DishDetailsRawDataItem item )
        {
            if (HasImport(item)) //不重复导入
            {
                return;
            }
            if(item.Name.IsNotNullOrEmpty() 
                && item.DataId.IsNotNullOrEmpty())
            {
                Dish dish = FromRawData(item);
                _dishRepository.Insert(dish);

            }
                 
        }

        private bool HasImport(DishDetailsRawDataItem item)
        {
            return _dishRepository.Count( d => d.ImportId == item.DataId ) > 0;
        }

        private Dish FromRawData(DishDetailsRawDataItem item)
        {
            return new Dish()
            {
                ImportId = item.DataId,
                Description = item.Name.ToUTF8(),
                HPhoto = item.SmallImageLocalPath().ToSlash(),
                BPhoto = item.BigImageLocalPath().ToSlash(),
                DishCategory = item.Tags,
                Taste = item.Taste,
                CookTime = item.CookTime,
                Difficulty = item.Difficulty,
                CookMethod = item.Technology,
                Cookerys = GetCookerys(item),
                DishBoms = GetDishBoms(item.DishBom,item.AuxDishBom),
            };
        }

        private ICollection<Cookery> GetCookerys(DishDetailsRawDataItem item)
        {
            if(item.Cookery == null)
            {
                return null;
            }

            foreach(var r in item.Cookery)
            {
                r.Content = r.Content.ToUTF8();
            }

            int start = 1;
            return item.Cookery.Select(r => new Cookery()
            {
                Description = "abc",//r.Content.Substring(0, r.Content.Length > 30 ? 30 : r.Content.Length),
                Content = r.Content,
                Photo = item.CookeryLocalPath(start).ToSlash(),
                Order = start++,
            } ).ToList();
        }

        private ICollection<DishBom> GetDishBoms(DishBomRawData dishBom, DishBomRawData auxDishBom)
        {
            List<DishBom> boms = new List<DishBom>();
            AddBomItems(dishBom, boms, true);
            AddBomItems(auxDishBom, boms, false);

            return boms;
        }

        private void AddBomItems(DishBomRawData dishBom, List<DishBom> boms, bool isMain)
        {
            if( dishBom == null)
            {
                return;
            }

            foreach (var r1 in dishBom)
            {
                long foodMaterialId = GetFoodMaterialId(r1.EnglishName);
                if (foodMaterialId > 0)
                {
                    boms.Add(new DishBom()
                    {
                        MatchingDescription = r1.Use,
                        FoodMaterialId = foodMaterialId,
                        IsMain = isMain,
                    });
                }
            }
        }

        private long GetFoodMaterialId(string englishName)
        {
            var entity = _foodMaterialRepository.FirstOrDefault( fm => fm.EnglishName == englishName );
            return entity == null ? 0 : entity.Id;
        }
    }
}
