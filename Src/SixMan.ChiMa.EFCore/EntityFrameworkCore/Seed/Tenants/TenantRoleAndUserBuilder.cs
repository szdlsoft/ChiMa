﻿using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using SixMan.ChiMa.Domain.Authorization;
using SixMan.ChiMa.Domain.Authorization.Roles;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.Zero.Authorization.Users;

namespace SixMan.ChiMa.EFCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly ChiMaDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(ChiMaDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // System role and user for host
            CreateRoleAndDefaulUser(StaticRoleNames.Host.System, PermissionNames.System, StaticUserNames.System);

            // Admin role

            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();

                // Grant all permissions to admin role
                var permissions = PermissionFinder
                    .GetAllPermissions(new ChiMaAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRole.Id
                        });
                }

                _context.SaveChanges();
            }

            // Admin user

            var adminUser = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == AbpUserBase.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com");
                adminUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(adminUser, "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();

                // User account of admin user
                if (_tenantId == 1)
                {
                    _context.UserAccounts.Add(new UserAccount
                    {
                        TenantId = _tenantId,
                        UserId = adminUser.Id,
                        UserName = AbpUserBase.AdminUserName,
                        EmailAddress = adminUser.EmailAddress
                    });
                    _context.SaveChanges();
                }
            }
        }

        private void CreateRoleAndDefaulUser(string roleName, string permissionName, string userName)
        {
            // 建role
            var role = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == roleName);
            if (role == null)
            {
                role = _context.Roles.Add(new Role(_tenantId, roleName, roleName) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();

                // 设权限
                _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permissionName,
                            IsGranted = true,
                            RoleId = role.Id
                        });
                _context.SaveChanges();
            }

            //加用户
            var user = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == userName);
            if (user == null)
            {
                var newUser = new User
                {
                    TenantId = _tenantId,
                    UserName = userName,
                    Name = userName,
                    Surname = userName,
                    EmailAddress = $"{userName}@aspnetboilerplate.com",
                    IsEmailConfirmed = true,
                    IsActive = true,
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" // 123qwe
                };
                newUser.SetNormalizedNames();

                user = _context.Users.Add(newUser).Entity;
                _context.SaveChanges();

                // Assign user role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, user.Id, role.Id));
                _context.SaveChanges();

            }



        }
    }
}
