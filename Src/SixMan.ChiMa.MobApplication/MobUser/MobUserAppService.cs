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
using System.IdentityModel.Tokens.Jwt;
using Abp.Events.Bus;
using SixMan.ChiMa.Domain;

namespace SixMan.ChiMa.Application.MobUser
{
    public class MobUserAppService
        : MobileAppServiceBase<User, MobUserDto, MobCreateUserDto, MobUserDto>
        , IMobUserAppService
    {
        public const string MOB_ROLE = "Mob";
        public IEventBus EventBus { get; set; }

        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public MobUserAppService(IRepository<User, long> repository,
                                UserManager userManager,
                                RoleManager roleManager,
                                IRepository<Role> roleRepository,
                                IPasswordHasher<User> passwordHasher) 
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }   
  
        public async Task<MobUserDto> Create(MobCreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);
            user.Name = user.UserName;
            user.Surname = user.UserName;
            user.EmailAddress = $"{user.UserName}@126.com";
            user.IsActive = true;

            user.TenantId = AbpSession.TenantId;
            user.Password = _passwordHasher.HashPassword(user, input.Password);
            user.IsEmailConfirmed = true;

            CheckErrors(await _userManager.CreateAsync(user));

            //EnsureRole();
            //CheckErrors(await _userManager.SetRoles(user, new string[] { MOB_ROLE }));

            CurrentUnitOfWork.SaveChanges();

            EventBus.Trigger(new MobUserCreateEvent()
            {
                User = user,
                FamilyId = input.FamilyId
            });

            return MapToEntityDto(user);
        }

        private async void EnsureRole()
        {
            var role = await _roleManager.GetRoleByNameAsync(MOB_ROLE);
            if( role == null)
            {
                await _roleManager.CreateAsync(new Role()
                {
                    TenantId = AbpSession.TenantId,
                    Name = MOB_ROLE,
                });
            }
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }       
    }
}
