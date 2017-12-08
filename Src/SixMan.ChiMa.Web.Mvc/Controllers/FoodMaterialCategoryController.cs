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
using SixMan.ChiMa.Web.Models;
using SixMan.ChiMa.Application.Base;

namespace SixMan.ChiMa.Web.Controllers
{
    public class FoodMaterialCategoryController
        : ChiMaControllerBase
    {
        private readonly IFoodMaterialCategoryAppService _appService;

        protected override string ServiceName => throw new NotImplementedException();

        public FoodMaterialCategoryController(IFoodMaterialCategoryAppService appService)
        {
            _appService = appService;
        }


        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = PagedResultVM.DEFAULT_PAGE_SIZE,
                        CancellationToken cancellationToken = default(CancellationToken))
        {
            var reqestDto = new SortSearchPagedResultRequestDto()
            {
                Sorting = "Name",
                MaxResultCount = pageSize,
                SkipCount = (pageNumber * pageSize) - pageSize
            };
            var vm = (await _appService.GetAll(reqestDto))
                .ToPagedResultVM(pageNumber, pageSize);

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
