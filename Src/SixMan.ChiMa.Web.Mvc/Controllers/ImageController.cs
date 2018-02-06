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
            string sImgRootFolder = Path.Combine(sWebRootFolder, "Images");

            FileInfo file = new FileInfo(Path.Combine(sImgRootFolder, photoFilePath));
            using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
            {
                imgfile.CopyTo(fs);
                fs.Flush();
            }
            return Json(photoFilePath);
        }
    }
}