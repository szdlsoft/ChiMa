using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixMan.ChiMa.Application
{
    public interface IMobileAppService<TEntityDto, TCreateInput, TUpdateInput>
        : ICrudAppService<TEntityDto, long, PagedAndSortedResultRequestDto, TCreateInput, TUpdateInput, EntityDto<long>, EntityDto<long>>
           where TEntityDto : IEntityDto<long>
           where TUpdateInput : IEntityDto<long>
          
    {
    }

    public interface IReadAppService<TEntityDto>
        where TEntityDto : IEntityDto<long>
    {
        TEntityDto Get(IEntityDto<long> input);
    }
}
