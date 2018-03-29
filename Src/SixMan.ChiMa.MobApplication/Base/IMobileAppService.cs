using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    //public interface IMobileAppService<TEntityDto, TCreateInput, TUpdateInput>
    //    : 
    //    //ICrudAppService<TEntityDto, long, PagedAndSortedResultRequestDto, TCreateInput, TUpdateInput, EntityDto<long>, EntityDto<long>>
    //     //, 
    //    IReadAppService<TEntityDto>
    //    //, IDeleteAppService
    //       where TEntityDto : IEntityDto<long>
    //       where TUpdateInput : IEntityDto<long>
          
    //{
    //}

    public interface ICreateAppService<TEntityDto, TCreateInput>
        : IApplicationService, ITransientDependency, IMobileAppService
        where TEntityDto : IEntityDto<long>
    {
        TEntityDto Create(TCreateInput input);
    }

    public interface IUpdateAppService<TEntityDto, TUpdateInput>
        : IApplicationService, ITransientDependency, IMobileAppService
        where TEntityDto : IEntityDto<long>
        where TUpdateInput : IEntityDto<long>
    {
        TEntityDto Update(TUpdateInput input);
    }

    public interface IReadAppService<TEntityDto>
        :  IMobileAppService
        where TEntityDto : IEntityDto<long>
    {
        TEntityDto Get(EntityDto<long> input);
    }

    public interface IDeleteAppService
    {
        void Delete(EntityDto<long> input);

    }

    public interface IMobileAppService
        : IApplicationService, ITransientDependency
    {

    }
}
