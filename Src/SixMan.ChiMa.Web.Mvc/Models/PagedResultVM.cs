using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.Models
{
    public class PagedResultVM<T>
        : PagedResultDto<T>
    {        
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
       
    }

    public static class PagedResultVM
    {
        public const int DEFAULT_PAGE_SIZE = 10;
        public static PagedResultVM<T> ToPagedResultVM<T>(this PagedResultDto<T> dto, int pageNumber, int pageSize)
            where T: class
        {
            return new PagedResultVM<T>()
            {
                Items = dto.Items,
                TotalCount = dto.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
