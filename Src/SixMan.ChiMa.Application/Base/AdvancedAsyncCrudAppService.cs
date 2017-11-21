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

namespace SixMan.ChiMa.Application.Base
{
    public class AdvancedAsyncCrudAppService<TEntity, TEntityDto>
        : AsyncCrudAppService<TEntity, TEntityDto, long, SortSearchPagedResultRequestDto, TEntityDto, TEntityDto>
        , IAdvancedAsyncCrudAppService<TEntityDto>
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

        //protected override IQueryable<TEntity> CreateFilteredQuery(SortSearchPagedResultRequestDto input)
        //{
        //    var query = base.CreateFilteredQuery(input);
        //    if (input.Search.IsNotNullOrEmpty())
        //    {
        //        //query = from c in query
        //        //where EF.Functions.Like("Name", $"%{input.Search}%")
        //        //select c;
        //        //string whereClause = $"Name like '%{input.Search}%'";
        //        string whereClause = input.Search;
        //        query = query.Where(whereClause);
        //    }

        //    return query;
        //}


    }
}
