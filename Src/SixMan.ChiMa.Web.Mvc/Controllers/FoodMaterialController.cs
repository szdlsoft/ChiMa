using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
using SixMan.ChiMa.Web.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SixMan.ChiMa.Application.Food.Dto;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SixMan.ChiMa.Web.Controllers
{
    public class FoodMaterialController
        : ChiMaControllerBase
    {
        private readonly IFoodMaterialAppService _appService;
        private IHostingEnvironment _hostingEnvironment;
        public IModelMetadataProvider metaProvider { get; set; }

        public IFoodMaterialCategoryAppService categoryService { get; set; }


        public FoodMaterialController(IFoodMaterialAppService appService, IHostingEnvironment hostingEnvironment)
        {
            _appService = appService;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            var vm = new EditFoodMaterialModalViewModel()
            {
                //Current = new Application.Food.Dto.FoodMaterialDto(),
                Categories = categoryService.GetAll(SortSearchPagedResultRequestDto.All)
                        .Result.Items
                        .Select(c => new { Id = c.Id, Name = c.Name })
                        .ToJson(),
                //AspCategories = categoryService.GetAll(SortSearchPagedResultRequestDto.All)
                //        .Result.Items
                //        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                //        .ToList(),
                Meta = metaProvider.GetMetadataForType(typeof(FoodMaterialDto))
            };

            vm.ModelExplorer = new ModelExplorer(metaProvider, vm.Meta, new FoodMaterialDto());

            return View(vm);
        }

        
        [HttpPost]
        [UnitOfWork(false)]
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
                    //rowCount = 20;
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

        [HttpPost]
        [UnitOfWork(IsDisabled = true)]
        public IActionResult UploadImg(string photo, IFormFile imgfile)
        {            
            //string photo = Request.Form["photo"];
            //IFormFile imgfile = Request.Form.Files[0];
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sImgRootFolder = Path.Combine(sWebRootFolder, "Images");
            string sFileName = photo;
            FileInfo file = new FileInfo(Path.Combine(sImgRootFolder, sFileName));
            try
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    imgfile.CopyTo(fs);
                    fs.Flush();
                }
                return Content($"{photo} 上传成功");
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
