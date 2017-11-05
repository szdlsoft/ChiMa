using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Application.Category.Dto
{
    public class CategoryPagedAndSortedResultRequestDto
        : PagedAndSortedResultRequestDto
    {
        public CategoryPagedAndSortedResultRequestDto(string category)
        {
            Category = category;
        }

        public string Category { get; set; }

    }
}
