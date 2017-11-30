using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Application.Extensions;
using SixMan.ChiMa.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using SixMan.ChiMa.Application.Interface;
using Abp.Domain.Uow;

namespace SixMan.ChiMa.Application.Base
{
    public abstract class AdvancedAsyncCrudAppService<TEntity, TEntityDto>
        : AsyncCrudAppService<TEntity, TEntityDto, long, SortSearchPagedResultRequestDto, TEntityDto, TEntityDto>
        , IAdvancedAsyncCrudAppService<TEntityDto>
        , IImportFromExcel
        where TEntity : class, IEntity<long>,new()
        where TEntityDto : IEntityDto<long>
    {
        protected AdvancedAsyncCrudAppService(IRepository<TEntity, long> repository) : base(repository)
        {          

        }

        public TEntityDto Add()
        {
            return Repository.InsertWithId(new TEntity())
                        .ToDto<TEntity, TEntityDto>();
        }

        public void DeleteList(DeletListDto list)
        {
            var ids = list.Ids.Split(',').Select(id => long.Parse(id));
            ids.ToList().ForEach(id => Repository.Delete(Repository.Get(id)));
        }
       

        public override async Task<PagedResultDto<TEntityDto>> GetAll(SortSearchPagedResultRequestDto input)
        {           
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            query = ApplyInclude(query);


            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        protected virtual IQueryable<TEntity> ApplyInclude(IQueryable<TEntity> query)
        {
            return query;
        }

        public override async Task<TEntityDto> Create(TEntityDto input)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);

            await Repository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public override async Task<TEntityDto> Update(TEntityDto input)
        {
            CheckUpdatePermission();

            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        /// <summary>
        /// 导入一行数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected abstract int ImportRow(Dictionary<string, string> row);

        [UnitOfWork(false)]
        public int Import(List<Dictionary<string, string>> importData)
        {
            int count = 0;
            foreach (var row in importData)
            {
                count += ImportRow(row);
            }
            return count;
        }
    }
}
