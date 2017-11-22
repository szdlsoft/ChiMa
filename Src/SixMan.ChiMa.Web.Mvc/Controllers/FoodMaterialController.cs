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
                    var importData = new List<Dictionary<string, string>>();
                    for (int row = 5; row <= rowCount; row++)
                    {
                        var rowData = new Dictionary<string, string>();
                        for (int col = 1; col <= ColCount; col++)
                        {
                            var key = worksheet.Cells[2, col].Value?.ToString();
                            var value = worksheet.Cells[row, col].Value?.ToString();
                            if( key != null 
                                && value != null)
                            {
                                rowData[key] = value;
                            }
                        }
                        importData.Add(rowData);
                    }
                    int importCount = _appService.Import(importData);
                    System.IO.File.Delete(file.ToString());
                    return Content($"{excelfile.FileName}共{rowCount}行 导入{importCount}行");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
