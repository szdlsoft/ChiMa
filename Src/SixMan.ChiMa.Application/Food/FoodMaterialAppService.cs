﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace SixMan.ChiMa.Application.Food
{
    public class FoodMaterialAppService
       : AdvancedAsyncCrudAppService<FoodMaterial, FoodMaterialDto>
        , IFoodMaterialAppService

    {
        private IRepository<FoodMaterialCategory, long> _categoryRepository;
        public FoodMaterialAppService(IRepository<FoodMaterial, long> repository
                                    , IRepository<FoodMaterialCategory, long> categoryRepository) 
            : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        protected override IQueryable<FoodMaterial> CreateFilteredQuery(SortSearchPagedResultRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);
            if (input.Search.IsNotNullOrEmpty())
            {
                query = from c in query
                        where EF.Functions.Like(c.Description, $"%{input.Search}%")
                        select c;
            }

            return query;
        }

        protected override IQueryable<FoodMaterial> ApplyInclude(IQueryable<FoodMaterial> query)
        {
            query = query.Include(e => e.FoodMaterialCategory);
            return query;
        }

        public int Import(List<Dictionary<string,string>> importData)
        {
            int count = 0;
            foreach(var row in importData)
            {
                count += ImportRow(row);
            }
            return count;
        }

        private int ImportRow(Dictionary<string, string> row)
        {
            var fmDescription = row["Description"];
            FoodMaterial entity = Repository.GetAll().Where(e => e.Description == fmDescription).FirstOrDefault();
            if( entity == null)
            {
                entity = new FoodMaterial();
            }

            try
            {
                var categoryName = row["FoodMaterialCategory"];
                FoodMaterialCategory category = InsertOrGetCategory(categoryName);
                row.Remove("FoodMaterialCategory"); //删除免import出错

                entity.Import(row);
                entity.FoodMaterialCategory = category;

                Repository.InsertOrUpdate(entity);
                return 1;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        private FoodMaterialCategory InsertOrGetCategory(string categoryName)
        {
            var category = _categoryRepository.GetAll().Where(c=>c.Name == categoryName).FirstOrDefault();
            if( category == null)
            {
                category = new FoodMaterialCategory()
                {
                    Name = categoryName
                };
                category.Id = _categoryRepository.InsertAndGetId(category);
            }

            return category;
        }
    }
}
