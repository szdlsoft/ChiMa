using SixMan.ChiMa.Domain.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using SixMan.ChiMa.Domain.Authorization.Roles;
using Abp.IdentityFramework;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using SixMan.ChiMa.Domain.MultiTenancy;
using System.Security.Claims;
using Abp.Runtime.Security;
using Abp.Events.Bus;
using SixMan.ChiMa.Domain;
using Abp.Web.Models;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Domain.Mob;
using SixMan.ChiMa.DomainService.Mob;
using Abp.Domain.Uow;
using Abp.Authorization;
using SixMan.ChiMa.Domain.Authorization;

namespace SixMan.ChiMa.Application.MobUser
{
    /// <summary>
    /// 手机端用户服务
    /// </summary>
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
    public class MobUserAppService
        //: MobileAppServiceBase<User, MobUserDto, MobCreateUserDto, MobUserDto>
        : ApplicationService 
        //CrudAppServiceBase<User, MobUserDto, long, PagedAndSortedResultRequestDto, MobCreateUserDto, MobUserDto>
        , IMobUserAppService
    {
        //public const string MOB_ROLE = "Mob";
        public IEventBus EventBus { get; set; }

        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        ValidateDataManager _validateDataManager;
        ISMSSender _sMSSender;
        public MobUserAppService(IRepository<User, long> repository,
                                UserManager userManager,
                                RoleManager roleManager,
                                IRepository<Role> roleRepository,
                                IPasswordHasher<User> passwordHasher,
                                ValidateDataManager validateDataManager,
                                ISMSSender sMSSender) 
           // : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;

            _validateDataManager = validateDataManager;
            _sMSSender = sMSSender;
        }   
  
        //public async Task<MobUserDto> Create(MobCreateUserDto input)
        //{
        //    CheckCreatePermission();

        //    var user = ObjectMapper.Map<User>(input);
        //    user.Name = user.UserName;
        //    user.Surname = user.UserName;
        //    user.EmailAddress = $"{user.UserName}@126.com";
        //    user.IsActive = true;

        //    user.TenantId = AbpSession.TenantId;
        //    user.Password = _passwordHasher.HashPassword(user, input.Password);
        //    user.IsEmailConfirmed = true;

        //    CheckErrors(await _userManager.CreateAsync(user));

        //    //EnsureRole();
        //    //CheckErrors(await _userManager.SetRoles(user, new string[] { MOB_ROLE }));

        //    CurrentUnitOfWork.SaveChanges();

        //    EventBus.Trigger(new MobUserCreateEvent()
        //    {
        //        User = user,
        //        FamilyId = input.FamilyId
        //    });

        //    return MapToEntityDto(user);
        //}

        //private async void EnsureRole()
        //{
        //    var role = await _roleManager.GetRoleByNameAsync(MOB_ROLE);
        //    if( role == null)
        //    {
        //        await _roleManager.CreateAsync(new Role()
        //        {
        //            TenantId = AbpSession.TenantId,
        //            Name = MOB_ROLE,
        //        });
        //    }
        //}

        private  void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        /// <summary>
        /// 用户注册
        /// 需要系统用户的token
        /// </summary>
        /// <param name="userRegisterIntput"></param>
        [UnitOfWork(IsDisabled = true)]
        [AbpAuthorize(PermissionNames.System)]
        public  void Register(RegisterIntput userRegisterIntput)
        {
            _validateDataManager.CheckValidateCode(userRegisterIntput.Mobile, ValidateType.Register, userRegisterIntput.ValidateCode);
            CreateUser(userRegisterIntput);
        }

        private void CreateUser(RegisterIntput userRegisterIntput)
        {
            //CheckCreatePermission();

            var user = new User();
            user.UserName = userRegisterIntput.Mobile;
            user.Name = user.UserName;
            user.Surname = user.UserName;
            user.EmailAddress = $"{user.UserName}@126.com";
            user.IsActive = true;

            user.TenantId = AbpSession.TenantId;
            user.Password = _passwordHasher.HashPassword(user, userRegisterIntput.Password);
            user.IsEmailConfirmed = true;

            CheckErrors(_userManager.CreateAsync(user).Result);

            CurrentUnitOfWork.SaveChanges();

            EventBus.Trigger(new MobUserCreateEvent()
            {
                User = user,
                FamilyId = userRegisterIntput.FamilyId
            });
        }

        /// <summary>
        /// 重设密码
        /// 需要系统用户的token
        /// </summary>
        /// <param name="userResetPasswordIntput"></param>
        [UnitOfWork(IsDisabled = true)]
        [AbpAuthorize(PermissionNames.System)]
        public  void ResetPassword(ResetPasswordIntput userResetPasswordIntput)
        {
            _validateDataManager.CheckValidateCode(userResetPasswordIntput.Mobile, ValidateType.ResetPassword, userResetPasswordIntput.ValidateCode);
            User user =  _userManager.FindByNameAsync(userResetPasswordIntput.Mobile).Result;
            if( user != null)
            {
                string token =  _userManager.GeneratePasswordResetTokenAsync(user).Result;
                CheckErrors(  _userManager.ResetPasswordAsync(user, token, userResetPasswordIntput.NewPassword).Result);
            }
            else
            {
                throw new Abp.UI.UserFriendlyException($"{userResetPasswordIntput.Mobile} 用户不存在!");
            }
        }
        /// <summary>
        /// 发送短信验证码
        /// 需要系统用户的token
        /// </summary>
        /// <param name="sendValidateCodeInput"></param>
        [UnitOfWork(IsDisabled = true)]
        [AbpAuthorize(PermissionNames.System)]
        public void SendValidateCode(SendValidateCodeInput sendValidateCodeInput)
        {
            // 生成
            SMessage message = _validateDataManager.Build(sendValidateCodeInput.Mobile, sendValidateCodeInput.ValidateType);
            // 发送
            _sMSSender.Send(message);
        }
        /// <summary>
        /// 取消（删除）注册用户
        /// </summary>
        /// <param name="unUserRegisterIntput"></param>
        public void UnRegister(UnRegisterIntput unUserRegisterIntput)
        {
            //_validateDataManager.CheckValidateCode(unUserRegisterIntput.Mobile, ValidateType.UnRegister, unUserRegisterIntput.ValidateCode);

            User user = _userManager.FindByNameAsync(unUserRegisterIntput.Mobile).Result;
            if (user != null)
            {
                CheckErrors( _userManager.DeleteAsync(user).Result);
            }
            else
            {
                throw new Abp.UI.UserFriendlyException($"{unUserRegisterIntput.Mobile} 用户不存在!");
            }
        }
    }
}
