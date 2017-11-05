using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Controllers;
using SixMan.ChiMa.Web.Models.Category;
using SixMan.ChiMa.Web.Models.FoodMaterialCategory;
using SixMan.ChiMa.Web.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.Controllers
{
    public class FoodMaterialCategoryController
        : ChiMaControllerBase
    {
        private readonly IFoodMaterialCategoryAppService _appService;

        public FoodMaterialCategoryController(IFoodMaterialCategoryAppService appService)
        {
            _appService = appService;
        }


        public async Task<IActionResult> Index()
        {
            var fmcs = (await _appService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var vm = new FoodMaterialCategoryListViewModel()
            {
                Categories = fmcs,
            };

            return View(vm);
        }

        public async Task<ActionResult> EditFoodMaterialCategoryModal(long categoryId)
        {
            var fmc = await _appService.Get(new EntityDto<long>(categoryId));
            var vm = new EditFoodMaterialCategoryModalViewModel()
            {
                Category = fmc,
            };
            return View("_EditFoodMaterialCategoryModal", vm);
        }
    }
}
