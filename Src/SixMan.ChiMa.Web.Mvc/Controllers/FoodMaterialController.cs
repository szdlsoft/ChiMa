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
using SixMan.ChiMa.Application.Interface;

namespace SixMan.ChiMa.Web.Controllers
{
    public class FoodMaterialController
        : ChiMaControllerBase
    {
        private readonly IFoodMaterialAppService _appService;
        //private IHostingEnvironment _hostingEnvironment;
        public IModelMetadataProvider metaProvider { get; set; }

        public IFoodMaterialCategoryAppService categoryService { get; set; }

        protected override string ServiceName => "FoodMaterial";

        public FoodMaterialController(IFoodMaterialAppService appService
            )
        {
            _appService = appService;
        }

        public ActionResult Index()
        {
            var vm = new EditFoodMaterialModalViewModel()
            {
                Categories = categoryService.GetAll(SortSearchPagedResultRequestDto.All)
                        .Result.Items
                        .Select(c => new { Id = c.Id, Name = c.Name })
                        .ToJson(),
                Meta = metaProvider.GetMetadataForType(typeof(FoodMaterialDto))
            };

            vm.ModelExplorer = new ModelExplorer(metaProvider, vm.Meta, new FoodMaterialDto());

            return View(vm);
        }

        //protected override int Import(ExcelWorksheet worksheet)
        //{
        //    int rowCount = worksheet.Dimension.Rows;
        //    int ColCount = worksheet.Dimension.Columns;
        //    var importData = new List<Dictionary<string, string>>();
        //    //rowCount = 20;
        //    for (int row = 5; row <= rowCount; row++)
        //    {
        //        var rowData = new Dictionary<string, string>();
        //        for (int col = 1; col <= ColCount; col++)
        //        {
        //            var key = worksheet.Cells[2, col].Value?.ToString();
        //            var value = worksheet.Cells[row, col].Value?.ToString();
        //            if (key != null
        //                && value != null)
        //            {
        //                rowData[key] = value;
        //            }
        //        }
        //        importData.Add(rowData);
        //    }
        //    int importCount = _appService.Import(importData);
        //    return importCount;
        //}

        protected override ImportTaskInfo BuildImportWork(ExcelWorksheet worksheet)
        {
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
                    if (key != null
                        && value != null)
                    {
                        rowData[key] = value;
                    }
                }
                //过滤掉非法行
                if (string.IsNullOrEmpty(rowData["Description"]))
                {
                    continue;
                }
                importData.Add(rowData);
            }

            return _appService.BuildImportWork(importData, "食材导入");
        }


    }
}
