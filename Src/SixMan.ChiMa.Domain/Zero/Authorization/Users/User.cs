using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SixMan.ChiMa.Domain.Family;

namespace SixMan.ChiMa.Domain.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public UserInfo UserInfo { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }

        public static User CreateTeantUser(int tenantId, string userName, string password )
        {
            var user = new User()
            {
                TenantId = tenantId,
                UserName = userName,
                Name = userName,
                Surname = userName,
                EmailAddress = $"{userName}@chima.com",
                IsEmailConfirmed = true,
                IsActive = true,
                //Password =  // 123qwe
            };
            user.SetNormalizedNames();
            user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, password);
            return user;
        }
    }
    }
