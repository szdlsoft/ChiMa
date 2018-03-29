using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Domain.Uow;
using Abp.Web.Models;
using Microsoft.AspNetCore.Http;
using Abp.AspNetCore.Mvc.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SixMan.ChiMa.Domain.Extensions;

namespace SixMan.ChiMa.Web.Mvc.Controllers
{
    public class ImageController : AbpController
    {
        public IHostingEnvironment _hostingEnvironment { get; set; }
        [HttpPost]
        [UnitOfWork(IsDisabled = true)]
        [WrapResult]
        public IActionResult Upload(string photoFilePath, IFormFile imgfile)
        {
            //string photo = Request.Form["photo"];
            //IFormFile imgfile = Request.Form.Files[0];
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            //string sImgRootFolder = Path.Combine(sWebRootFolder, "Images");
            string phsicalPath = Path.Combine(sWebRootFolder, photoFilePath.ToAntiSlash());
            //FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, photoFilePath));
            try
            {
                using (FileStream fs = new FileStream(phsicalPath, FileMode.Create))
                {
                    imgfile.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(photoFilePath);
        }
    }
}