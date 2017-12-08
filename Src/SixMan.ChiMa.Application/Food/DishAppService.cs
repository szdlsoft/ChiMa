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
        public IRepository<DishBom, long> _dishBomRepository { get; set; }
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
            foreach( var d in dto.DishBoms)
            {
                d.FoodMaterialName = entity.DishBoms.Where(e => e.Id == d.Id).FirstOrDefault()?.FoodMaterial?.Description;
            }
            //dto.Photo = dto.Photo ?? $"Dish/{entity.Id}.jpg";

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
            var count = Repository.GetAll().AsNoTracking()
                        .Where(e => e.ImportId == ImportId).Count();
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

                Repository.Insert(entity); //会新增关联字表呢？
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
                var vs = bom.Split(':');
                long foodImportId = long.Parse(vs[0]);
                double match = double.Parse(vs[1]);
                var fdmId = _foodMaterialRepository.GetAll().AsNoTracking()
                                       .Where(fm => fm.ImportId == foodImportId)
                                       .FirstOrDefault()?.Id;
                if( fdmId == null)
                {
                    throw new Exception($"{foodImportId} 找不到");
                }
                var dm = new DishBom()
                {
                    FoodMaterialId = fdmId.Value,
                    Matching = match
                };

                result.Add(dm);
            }

            return result;
        }

        protected override void Delete(Dish entity)
        {
            _dishBomRepository.Delete(db => db.DishId == entity.Id);
            Repository.Delete(entity);
        }

        protected override void AttachChild(DishDto dto, Dish entity)
        {
            var dishBoms = dto.DishBoms;
            entity.DishBoms = new List<DishBom>(); //取消关联

            foreach (var item in dishBoms)
            {
                DishBom dbEntity = null;
                if (item.Id == 0)
                {
                    if (!item.ClientDelete)
                    {
                        dbEntity = ObjectMapper.Map<DishBom>(item);
                        //_dishBomRepository.Insert(dbEntity);
                    }
                }
                else
                {
                    if (!item.ClientDelete)
                    {
                        dbEntity = _dishBomRepository.Get(item.Id);
                        ObjectMapper.Map(item, dbEntity);
                        //_dishBomRepository.Update(dbEntity);
                    }
                    else
                    {
                        _dishBomRepository.Delete(item.Id);
                    }
                }
                if(dbEntity != null)
                {
                    entity.DishBoms.Add(dbEntity);
                }
            }

        }
    }
}
