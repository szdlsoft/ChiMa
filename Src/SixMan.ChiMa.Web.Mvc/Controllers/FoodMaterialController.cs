using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Application.Base;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFoodMaterias(int offset = 0, int limit = PagedResultVM.DEFAULT_PAGE_SIZE,
                        CancellationToken cancellationToken = default(CancellationToken))
        {
            var reqestDto = new SortSearchPagedResultRequestDto()
            {
                Sorting = "Description",
                MaxResultCount = limit,
                SkipCount = (offset * limit)
            };
            var result = _appService.GetAll(reqestDto).Result;
            //var vm = result.ToBootstrapTablePagedResultVM(offset, limit);

            return Json(result);
        }

        public async Task<ActionResult> EditFoodMaterialModal(long foodMaterialId)
        {
            var fmc = await _appService.Get(new EntityDto<long>(foodMaterialId));
            var vm = new EditFoodMaterialModalViewModel()
            {
                Current = fmc,
            };
            return View("_EditFoodMaterialModal", vm);
        }
    }
}
