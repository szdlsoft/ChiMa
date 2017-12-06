using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SixMan.ChiMa.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SixMan.ChiMa.Controllers
{
    public abstract class ChiMaControllerBase: AbpController
    {
        public IHostingEnvironment _hostingEnvironment { get; set; }
        protected ChiMaControllerBase()
        {
            LocalizationSourceName = ChiMaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected virtual int Import(ExcelWorksheet worksheet)
        {
            return 0;
        }

        [HttpPost]
        [UnitOfWork(IsDisabled = true)]
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

                    int importCount = 0
                        //Import(worksheet)
                        ;

                    string importWorkId = BuildImportWork(worksheet);

                    System.IO.File.Delete(file.ToString());
                    //return Json($"{excelfile.FileName}共{rowCount}行 导入{importCount}行");
                    return Json(importWorkId);
                }
            }
            finally 
            {
                //return Json(ex.Message);
            }
        }

        private string BuildImportWork(ExcelWorksheet worksheet)
        {
            return "abcd1234";
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
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
