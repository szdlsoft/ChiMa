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
using System.Threading;
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


        public async Task<IActionResult> Index(int pageNumber=1,   int pageSize=2,
                        CancellationToken cancellationToken = default(CancellationToken))
        {
            var reqestDto = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Name",
                MaxResultCount = pageSize,
                SkipCount = (pageNumber * pageSize) - pageSize
            };
            var result = (await _appService.GetAll(reqestDto));
            var vm = new FoodMaterialCategoryListViewModel()
            {
                Data = result.Items.ToList(),
                TotalItems = result.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
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
