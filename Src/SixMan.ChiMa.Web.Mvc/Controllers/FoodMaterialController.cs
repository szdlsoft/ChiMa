using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Controllers;
using SixMan.ChiMa.Web.Models;
using SixMan.ChiMa.Web.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.Controllers
{
    public class FoodMaterialController
        : ChiMaControllerBase
    {
        private readonly IFoodMaterialAppService _appService;

        public FoodMaterialController(IFoodMaterialAppService appService)
        {
            _appService = appService;
        }


        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = PagedResultVM.DEFAULT_PAGE_SIZE,
                        CancellationToken cancellationToken = default(CancellationToken))
        {
            var reqestDto = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Description",
                MaxResultCount = pageSize,
                SkipCount = (pageNumber * pageSize) - pageSize
            };
            var vm = (await _appService.GetAll(reqestDto))
                .ToPagedResultVM(pageNumber, pageSize);

            return View(vm);
        }

        public async Task<ActionResult> EditFoodMaterialModal(long categoryId)
        {
            var fmc = await _appService.Get(new EntityDto<long>(categoryId));
            var vm = new EditFoodMaterialModalViewModel()
            {
                Current = fmc,
            };
            return View("_EditFoodMaterialModal", vm);
        }
    }
}
