using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Extensions;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixMan.ChiMa.Application.Food
{
    public class DishAppService
       : AdvancedAsyncCrudAppService<Dish, DishDto>
        , IDishAppService

    {
        private IRepository<FoodMaterial, long> _foodMaterialRepository;
        public DishAppService(IRepository<Dish, long> repository
                                    , IRepository<FoodMaterial, long> foodMaterialRepository) 
            : base(repository)
        {
            _foodMaterialRepository = foodMaterialRepository;
        }

        protected override IQueryable<Dish> CreateFilteredQuery(SortSearchPagedResultRequestDto input)
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

        protected override IQueryable<Dish> ApplyInclude(IQueryable<Dish> query)
        {
            query = query.Include(d => d.DishBoms)
                           .ThenInclude(b => b.FoodMaterial);
            return query;
        }

        protected override DishDto MapToEntityDto(Dish entity)
        {
            var dto = base.MapToEntityDto(entity);
            dto.DishBoms = entity.DishBoms.Select( d => new DishBomDto()
                                        {
                                            Id = d.Id,
                                            FoodMaterialName = d.FoodMaterial.Description,
                                            Matching = d.Matching
                                        } ).ToList();
            dto.Photo = dto.Photo ?? $"Dish/{entity.Id}.jpg";

            return dto;
        }       
        /// <summary>
        /// 导入一行数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected override int ImportRow(Dictionary<string, string> row)
        {
            var ImportId = long.Parse( row["ImportId"]); //防止重复导入
            var count = Repository.GetAll().Where(e => e.ImportId == ImportId).Count();
            if( count >  0)
            {
                return 0;
            }

            try
            {
                var entity = new Dish();
                IList<DishBom> boms = GetDishBoms(row["boms"] , entity);

                entity.Import(row);
                entity.DishBoms = boms;

                Repository.InsertOrUpdate(entity); //会新增关联字表呢？
                return 1;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return 0;
            }
        }

        private IList<DishBom> GetDishBoms(string boms, Dish dish)
        {
            List<DishBom> result = new List<DishBom>();
            foreach ( var bom in boms.Split(';'))
            {
                var vs = bom.Split(',');
                long foodImportId = long.Parse(vs[0]);
                double match = double.Parse(vs[1]);
                var dm = new DishBom()
                {
                    FoodMaterial = _foodMaterialRepository.GetAll()
                                       .Where(fm => fm.ImportId == foodImportId)
                                       .FirstOrDefault(),
                    Dish = dish,
                    Matching = match
                };

                result.Add(dm);
            }

            return result;
        }
    }
}
