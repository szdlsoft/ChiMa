﻿using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using SixMan.ChiMa.Application.Authorization;
using SixMan.ChiMa.Controllers;
using SixMan.ChiMa.Application.Users;
using SixMan.ChiMa.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Domain.Authorization;
using SixMan.ChiMa.Web.Models.FoodMaterialCategory;

namespace SixMan.ChiMa.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ChiMaControllerBase
    {
        private readonly IUserAppService _userAppService;

        protected override string ServiceName => throw new System.NotImplementedException();

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto {MaxResultCount = int.MaxValue})).Items; //Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel()
            {
                Users = users,
                Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
    }
}