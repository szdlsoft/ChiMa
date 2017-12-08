using Abp.Application.Services;
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
using Abp.Domain.Uow;

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

        protected override FoodMaterialDto MapToEntityDto(FoodMaterial entity)
        {
            var dto = base.MapToEntityDto(entity);
            dto.Category = entity.FoodMaterialCategory?.Name;
            //dto.FoodMaterialCategoryId = entity.FoodMaterialCategory?.Id;
            //dto.Photo = dto.Photo ?? $"FoodMaterial/{entity.Id}.jpg";

            return dto;
        }

        //[UnitOfWork(IsDisabled = true)]
        //public int Import(List<Dictionary<string,string>> importData)
        //{
        //    int count = 0;
        //    foreach(var row in importData)
        //    {
        //        count += ImportRow(row);
        //    }
        //    return count;
        //}

        protected override int ImportRow(Dictionary<string, string> row)
        {
            var fmDescription = row["Description"];
            var count = Repository.GetAll().AsNoTracking().Where(e => e.Description == fmDescription).Count();
            if( count > 0 )
            {
                return 0;
            }

            try
            {
                FoodMaterial entity = new FoodMaterial();
                var categoryName = row["FoodMaterialCategory"];
                FoodMaterialCategory category = InsertOrGetCategory(categoryName);
                row.Remove("FoodMaterialCategory"); //删除免import出错

                entity.Import(row);
                entity.FoodMaterialCategoryId = category.Id; // 必须用id,不能用
                ///entity.FoodMaterialCategory = category; // 必须用id,不能用，否则会插入异常

                Repository.Insert(entity); //相关数据会自动添加吗？
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
            var category = _categoryRepository.GetAll().AsNoTracking().Where(c=>c.Name == categoryName).FirstOrDefault();
            if( category == null)
            {
                category = new FoodMaterialCategory()
                {
                    Name = categoryName
                };
                category.Id = _categoryRepository.InsertAndGetId(category); //似乎必须加上！
            }

            return category;
        }
    }
}
