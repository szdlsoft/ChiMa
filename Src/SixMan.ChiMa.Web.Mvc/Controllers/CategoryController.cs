using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Web.Startup;
using SixMan.ChiMa.Controllers;
using SixMan.ChiMa.Application.Food;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Category;
using SixMan.ChiMa.Web.Models.Category;
using SixMan.ChiMa.Application.Category.Dto;

namespace SixMan.ChiMa.Web.Mvc.Controllers
{
    public class CategoryController         
        : ChiMaControllerBase
    {       

        private readonly ICategoryAppService _appService;

        public CategoryController(ICategoryAppService appService)
        {
            _appService = appService;
        }


        public async Task<IActionResult> Index(string category)
        {
            var fmcs = (await _appService.GetAll(new CategoryPagedAndSortedResultRequestDto(category) { })).Items;
            var vm = new CategoryListViewModel()
            {
                Categories = fmcs,
                Category = category
            };

            ViewBag.CurrentPageName = PageNames.Category(category);
            return View(vm);
        }

        public async Task<ActionResult> EditCategoryModal(long categoryId, string category)
        {
            var fmc = await _appService.Get(new CategoryDto(categoryId,category));
            var vm = new EditCategoryModalViewModel()
            {
                Category = fmc,
            };
            return View("_EditCategoryModal", vm);
        }
    }
}