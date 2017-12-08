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
using Abp.BackgroundJobs;

namespace SixMan.ChiMa.Application.Base
{

    public  class AdvancedAsyncCrudAppService<TEntity, TEntityDto>
        : AsyncCrudAppService<TEntity, TEntityDto, long, SortSearchPagedResultRequestDto, TEntityDto, TEntityDto>
        , IAdvancedAsyncCrudAppService<TEntityDto>
        , IImportFromExcel
        where TEntity : class, IEntity<long>,new()
        where TEntityDto : IEntityDto<long>
    {
        public IBackgroundJobManager _backgroundJobManager { get; set; }

        protected AdvancedAsyncCrudAppService(IRepository<TEntity, long> repository) : base(repository)
        {          

        }

        public TEntityDto Add()
        {
            return Repository.InsertWithId(new TEntity())
                        .ToDto<TEntity, TEntityDto>();
        }

        protected virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        public virtual void DeleteList(DeletListDto list)
        {
            var ids = list.Ids.Split(',').Select(id => long.Parse(id));
            ids.ToList().ForEach(id => Delete(Repository.Get(id)));
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
       
        protected virtual void AttachChild(TEntityDto updateInput, TEntity entity)
        {

        }

        protected override void MapToEntity(TEntityDto updateInput, TEntity entity)
        {
            ObjectMapper.Map(updateInput, entity);
            AttachChild(updateInput, entity);
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
        protected virtual int ImportRow(Dictionary<string, string> row)
        {
            return 0;
        }

        //[UnitOfWork(IsDisabled=true)]
        //public int Import(List<Dictionary<string, string>> importData)
        //{
        //    int count = 0;
        //    foreach (var row in importData)
        //    {
        //        count += ImportRow(row);
        //    }
        //    return count;
        //}

        static ImportTaskInfo importTaskInfo = new ImportTaskInfo(); //导入任务信息单例

        [UnitOfWork(IsDisabled = true)]
        public ImportTaskInfo BuildImportWork(List<Dictionary<string, string>> importData, string taskId)
        {
            if(! importTaskInfo.IsRunning) //同时只能运行一个导入任务
            {

                importTaskInfo.TaskId = taskId;
                Task.Run(() => this.Execute(taskId, importData));
            }

            return importTaskInfo;
        }

        [UnitOfWork(IsDisabled = true)]
        private void Execute(string args, List<Dictionary<string, string>> _importData)
        {
            int count = 0;
            int total = _importData.Count;

            importTaskInfo.IsRunning = true;
            importTaskInfo.Complete = false;
            importTaskInfo.Cancel = false;
            importTaskInfo.Percent = 0;

            try {
                foreach (var row in _importData)
                {
                    if(importTaskInfo.Cancel)
                    {
                        break;
                    }

                    ImportRow(row);

                    importTaskInfo.Percent = (100 * (++count))/ total;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);                
            }
            finally
            {
                importTaskInfo.Complete = true;
                importTaskInfo.IsRunning = false;
            } 
        }

        public ImportTaskInfo QueryWork(string taskId)
        {
            return importTaskInfo;
        }

        public ImportTaskInfo CancelWork(string taskId)
        {
            importTaskInfo.Cancel = true;
            return importTaskInfo;
        }
    }
}
