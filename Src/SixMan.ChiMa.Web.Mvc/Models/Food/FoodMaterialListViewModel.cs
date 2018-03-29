using System.Collections.Generic;
using SixMan.ChiMa.Application.Roles.Dto;
using SixMan.ChiMa.Application.Users.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using Abp.Application.Services.Dto;
using cloudscribe.Pagination.Models;

namespace SixMan.ChiMa.Web.Models.Food
{
    public class FoodMaterialListViewModel : PagedResult<FoodMaterialCategoryDto>
    {
        //public IReadOnlyList<FoodMaterialCategoryDto> Categories { get; set; }
        //public PagedAndSortedResultRequestDto RequestDto { get; set; }

    }
}