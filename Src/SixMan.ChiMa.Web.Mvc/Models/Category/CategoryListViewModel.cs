using System.Collections.Generic;
using SixMan.ChiMa.Application.Roles.Dto;
using SixMan.ChiMa.Application.Users.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using SixMan.ChiMa.Application.Category.Dto;

namespace SixMan.ChiMa.Web.Models.Category
{
    public class CategoryListViewModel
    {
        public IReadOnlyList<CategoryDto> Categories { get; set; }

        public string Category { get; set; }
    }
}