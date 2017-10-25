using System.Collections.Generic;
using SixMan.ChiMa.Application.Roles.Dto;
using SixMan.ChiMa.Application.Users.Dto;
using SixMan.ChiMa.Application.Food.Dto;

namespace SixMan.ChiMa.Web.Models.FoodMaterialCategory
{
    public class FoodMaterialCategoryListViewModel
    {
        public IReadOnlyList<FoodMaterialCategoryDto> Categories { get; set; }

    }
}