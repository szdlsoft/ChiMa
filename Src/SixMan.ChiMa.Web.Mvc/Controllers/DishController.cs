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
using SixMan.ChiMa.Application.Dish;

namespace SixMan.ChiMa.Web.Controllers
{
    public class DishController
        : ChiMaControllerBase
    {
        private readonly IDishAppService _appService;
        public IModelMetadataProvider metaProvider { get; set; }

        protected override string ServiceName => "Dish";

        public DishController(IDishAppService appService)
        {
            _appService = appService;
        }

        public ActionResult Index()
        {
            var vm = new MetaViewModel()
            {  
                Meta = metaProvider.GetMetadataForType(typeof(DishDto))
            };

            vm.ModelExplorer = new ModelExplorer(metaProvider, vm.Meta, new DishDto());

            return View(vm);
        }

        //protected override int Import(ExcelWorksheet worksheet)
        //{
        //    int rowCount = worksheet.Dimension.Rows;
        //    int ColCount = worksheet.Dimension.Columns;
        //    var importData = new List<Dictionary<string, string>>();
        //    //rowCount = 20;
        //    for (int row = 4; row <= rowCount; row++)
        //    {
        //        var rowData = new Dictionary<string, string>();
        //        //读菜品首行
        //        var sbBom = new StringBuilder();
        //        ProcessOneRow(worksheet, ColCount, row, sbBom,
        //            (key, value)=>
        //            {                        
        //                 rowData[key] = value;
        //            });

        //        //过滤掉非法行
        //        if (string.IsNullOrEmpty( rowData["Description"]))
        //        {
        //            continue;
        //        }

        //        //读菜品续行的bom
        //        //var sbBom = new StringBuilder();
        //        while (true)
        //        {
        //            var importId = worksheet.Cells[row + 1, 1].Value?.ToString();
        //            if (importId == null
        //                || importId != rowData["ImportId"])
        //            {
        //                break;
        //            }
        //            row ++;//下一行

        //            ProcessOneRow(worksheet, ColCount, row,sbBom);                    
        //        };

        //        rowData["boms"] =  sbBom.ToString();
        //        importData.Add(rowData);
        //    }
        //    int importCount = _appService.Import(importData);
        //    return importCount;
        //}

        private static void ProcessOneRow(ExcelWorksheet worksheet, int ColCount, int row, StringBuilder sbBom,  Action<string,string> cellAction = null)
        {
            for (int col = 1; col <= ColCount; col++)
            {
                var key = worksheet.Cells[1, col].Value?.ToString();
                var value = worksheet.Cells[row, col].Value?.ToString();
                if (key != null
                    && value != null)
                {
                    if (key == "bom_id")
                    {
                        if( sbBom.Length > 0)
                        {
                            sbBom.Append(";");
                        }
                        sbBom.Append(value);
                    }
                    else
                        if (key == "bom_match")
                    {
                        sbBom.Append(":" + value);
                    }
                    else
                    {
                        cellAction?.Invoke(key, value);
                    }
                }
            }
        }

        protected override ImportTaskInfo BuildImportWork(ExcelWorksheet worksheet)
        {
            int rowCount = worksheet.Dimension.Rows;
            int ColCount = worksheet.Dimension.Columns;
            var importData = new List<Dictionary<string, string>>();
            //rowCount = 20;
            for (int row = 4; row <= rowCount; row++)
            {
                var rowData = new Dictionary<string, string>();
                //读菜品首行
                var sbBom = new StringBuilder();
                ProcessOneRow(worksheet, ColCount, row, sbBom,
                    (key, value) =>
                    {
                        rowData[key] = value;
                    });
                    //过滤掉非法行
                    if (  ! rowData.ContainsKey("Description")
                         || string.IsNullOrEmpty(rowData["Description"]))
                    {
                        continue;
                    }
                    if (!rowData.ContainsKey("ImportId")
                         || string.IsNullOrEmpty(rowData["ImportId"]))
                    {
                        continue;
                    }
                //读菜品续行的bom
                //var sbBom = new StringBuilder();
                while (true)
                {
                    var importId = worksheet.Cells[row + 1, 1].Value?.ToString();
                    if (importId == null
                        || importId != rowData["ImportId"])
                    {
                        break;
                    }
                    row++;//下一行

                    ProcessOneRow(worksheet, ColCount, row, sbBom);
                };

                rowData["boms"] = sbBom.ToString();
                importData.Add(rowData);
            }

            return _appService.BuildImportWork(importData, "菜品导入");

        }
    }
   
}
