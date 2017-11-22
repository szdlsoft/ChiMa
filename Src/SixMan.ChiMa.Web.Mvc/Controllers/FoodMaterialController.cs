using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SixMan.ChiMa.Application.Base;
using SixMan.ChiMa.Application.Food;
using SixMan.ChiMa.Controllers;
using SixMan.ChiMa.Web.Models;
using SixMan.ChiMa.Web.Models.Food;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.Controllers
{
    public class FoodMaterialController
        : ChiMaControllerBase
    {
        private readonly IFoodMaterialAppService _appService;
        private IHostingEnvironment _hostingEnvironment;


        public FoodMaterialController(IFoodMaterialAppService appService, IHostingEnvironment hostingEnvironment)
        {
            _appService = appService;
            _hostingEnvironment = hostingEnvironment;
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

        [HttpPost]
        public IActionResult Import(IFormFile excelfile)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            try
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    excelfile.CopyTo(fs);
                    fs.Flush();
                }
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    bool bHeaderRow = true;
                    for (int row = 1; row <= 4; row++)
                    {
                        for (int col = 1; col <= ColCount; col++)
                        {
                            if (bHeaderRow)
                            {
                                sb.Append(worksheet.Cells[row, col].Value?.ToString() + "\t");
                            }
                            else
                            {
                                sb.Append(worksheet.Cells[row, col].Value?.ToString() + "\t");
                            }
                        }
                        sb.Append(Environment.NewLine);
                    }
                    return Content(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
