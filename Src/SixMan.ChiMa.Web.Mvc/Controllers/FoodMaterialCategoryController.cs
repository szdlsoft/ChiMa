using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Controllers;
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

        public FoodMaterialCategoryController(IFoodMaterialCategoryAppService roleAppService)
        {
            _appService = roleAppService;
        }


        public async Task<IActionResult> Index()
        {
            var fmcs = (await _appService.GetAll(new PagedAndSortedResultRequestDto())).Items;           

            return View(fmcs);
        }

        public async Task<ActionResult> EditRoleModal(long roleId)
        {
            var fmc = await _appService.Get(new EntityDto<long>(roleId));            
            return View("_EditRoleModal", fmc);
        }
    }
}
