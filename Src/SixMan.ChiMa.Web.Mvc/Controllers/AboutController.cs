﻿using Abp.AspNetCore.Mvc.Authorization;
using SixMan.ChiMa.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SixMan.ChiMa.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ChiMaControllerBase
    {
        protected override string ServiceName => throw new System.NotImplementedException();

        public ActionResult Index()
        {
            return View();
        }
	}
}