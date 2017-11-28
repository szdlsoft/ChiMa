using System.Collections.Generic;
using System.Linq;
using SixMan.ChiMa.Application.Roles.Dto;
using SixMan.ChiMa.Application.Users.Dto;
using SixMan.ChiMa.Application.Food.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SixMan.ChiMa.Web.TagHelpers;

namespace SixMan.ChiMa.Web.Models.Food
{
    public class EditFoodMaterialModalViewModel 
        : FoodMaterialDto
        , IModelExplorerProvider

    {
        //public FoodMaterialDto Current { get; set; }

        public HtmlString Categories { get; set; }

        //public List<SelectListItem> AspCategories { get; set; }

        public ModelMetadata Meta { get; set; }

        public ModelExplorer ModelExplorer { get; set; }

    }
}