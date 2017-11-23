using Abp.Application.Services.Dto;
using SixMan.ChiMa.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Base
{
    public class SortSearchPagedResultRequestDto
        : PagedResultRequestDto
        , ISortedResultRequest
    {
        public static SortSearchPagedResultRequestDto All = new SortSearchPagedResultRequestDto()
        {
            SkipCount =0,
            MaxResultCount = int.MaxValue
        };

        public string Search { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }

        private string _sorting;
        public string Sorting
        {
            get => _sorting ?? (_sorting = GetSorting());
            set => _sorting = value;
        }

        private string GetSorting()
        {

            if( Sort.IsNotNullOrEmpty()
                && Order.IsNotNullOrEmpty())
            {
                return $"{Sort} {Order}";
                //return $"Name ASC";
            }
            else
            {
                return null;
            }
        }
    }
}
