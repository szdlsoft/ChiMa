using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Base
{
    public interface IAdvancedAsyncCrudAppService<TEntityDto>
        : IAsyncCrudAppService<TEntityDto, long, SortSearchPagedResultRequestDto, TEntityDto, TEntityDto> 
        where TEntityDto : IEntityDto<long>
    {
        TEntityDto Add();
        void DeleteList(DeletListDto list);

    }
}
