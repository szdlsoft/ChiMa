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
using SixMan.UICommon.Extensions;
using Abp.Authorization;
using SixMan.ChiMa.Domain;
using Abp.UI;
using Abp.Domain.Repositories;
using SixMan.ChiMa.Domain.Family;
using SixMan.UICommon.Helper;

namespace SixMan.ChiMa.Web.Mvc.Controllers
{
    public class ImageController : AbpController
    {
        public IHostingEnvironment _hostingEnvironment { get; set; }
        public IRepository<UserInfo, long> _userInfoRepository { get; set; }
        /// <summary>
        /// 上传头像(jpg格式)：需要手机用户登陆
        /// </summary>
        /// <param name="imgfile">头像文件</param>
        /// <returns></returns>
        [Route("api/[controller]/[action]")]
        [HttpPost]
        [UnitOfWork(IsDisabled = true)]
        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        //[AbpAuthorize]
        public JsonResult UploadHeadPortrait( IFormFile imgfile )
        {
            //CurrentUnitOfWork.DisableFilter(ChimaDataFilter.FamillyDataFilter);

            if ( !AbpSession.UserId.HasValue)
            {
                throw new UserFriendlyException("请登陆！");
            }

            long userId = AbpSession.UserId.Value;
            Logger.Info($"UploadHeadPortrait userId:{userId}");
            var userInfo = _userInfoRepository.FirstOrDefault(ui => ui.User.Id == userId);
            if (userInfo == null)
            {              
                throw new UserFriendlyException("请使用手机用户登陆！");
            }

            string headPortraitImgPath = Path.Combine(  _hostingEnvironment.WebRootPath, ChiMaConsts.ImagePath, ChiMaConsts.HeadPortraitImgPath );
            FileHelper.EnsureDirectory( headPortraitImgPath );
            //string fileName = $"{userInfo.Id}.jpg";
            string phsicalPath = Path.Combine(headPortraitImgPath,  userInfo.HeadPortraitFileName );
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
                Logger.Fatal(ex.Message, ex);
                throw new UserFriendlyException(ex.Message);
            }
            return Json(userInfo.HeadPortrait);
        }
    }
}