using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Domain.Dish;
using SixMan.ChiMa.Domain.Extensions;
using SixMan.ChiMa.Domain.Family;
using SixMan.ChiMa.Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixMan.ChiMa.Application.Dish
{
    [AbpAuthorize]
    public class DishAppService
       : AdvancedAsyncCrudAppService<SixMan.ChiMa.Domain.Dish.Dish, DishDto>
        , IDishAppService

    {
        private IRepository<FoodMaterial, long> _foodMaterialRepository;
        IRepository<UserFavoriteDish, long> _userFavoriteDishRepository;
        public IRepository<DishBom, long> _dishBomRepository { get; set; }
        public DishAppService(IRepository<SixMan.ChiMa.Domain.Dish.Dish, long> repository
                                    , IRepository<FoodMaterial, long> foodMaterialRepository
                                    , IRepository<UserFavoriteDish, long> userFavoriteDishRepository) 
            : base(repository)
        {
            _foodMaterialRepository = foodMaterialRepository;
            _userFavoriteDishRepository = userFavoriteDishRepository;
        }

        protected override IQueryable<SixMan.ChiMa.Domain.Dish.Dish> CreateFilteredQuery(SortSearchPagedResultRequestDto input)
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

        protected override IQueryable<SixMan.ChiMa.Domain.Dish.Dish> ApplyInclude(IQueryable<SixMan.ChiMa.Domain.Dish.Dish> query)
        {
            query = query.Include(d => d.DishBoms)
                           .ThenInclude(b => b.FoodMaterial);
            return query;
        }

        protected override DishDto MapToEntityDto(SixMan.ChiMa.Domain.Dish.Dish entity)
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
                var entity = new SixMan.ChiMa.Domain.Dish.Dish();
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

        private IList<DishBom> GetDishBoms(string boms, SixMan.ChiMa.Domain.Dish.Dish dish)
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

        protected override void Delete(SixMan.ChiMa.Domain.Dish.Dish entity)
        {
            _dishBomRepository.Delete(db => db.DishId == entity.Id);
            Repository.Delete(entity);
        }

        protected override void AttachChild(DishDto dto, SixMan.ChiMa.Domain.Dish.Dish entity)
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

  

        //        菜谱（需要用户认证）
        //    2.1 获取需要的月份的菜谱计划，用于菜谱日历的显示
        //请求参数：年，月 GET
        //返回内容： 集合， 成员需包含内容： 年， 月， 日， 标记备注（可空）
        //    2.2 获取指定日期的菜谱，用于用户菜谱的显示
        //请求参数：年，月，日 GET
        //返回内容： 集合， 成员需包含内容：主键，年，月，日，菜名，横向图url，大图ur，类型索引号，类型（早，中，晚，加餐），星数，评论数，喜欢数， 我是否喜欢， 制作时间，制作难度，今日上桌数
        //注意： 当服务端收到语法后，哪2.1没有计划，需加入计划并生成一个新的内容，如已计划请返回原有数据。

        //    2.3 更新指定菜
        //请求参数： 2.2 获取到的主键 POST&PUT
        //返回内容：单对象，成员同2.2
        //        注意： POST为删除给定的菜，并生成一个新菜，主键可以保持不变。PUT为刷新给定的菜的内容
        //    2.4 删除指定菜
        //请求参数：2.2或2.3 获取到的主键 DELETE
        //返回内容：无，或出错信息
        //    2.5 新增菜
        //请求参数：类型索引号 POST
        //返回内容：单对象，成员同2.2    
        //    2.6 我的喜好变更
        //请求参数： 2.2或2.3获取到的主键，我的喜好选择， POST
        //返回内容：无或出错
        //注意：请注意喜欢数的同步

    }
}
