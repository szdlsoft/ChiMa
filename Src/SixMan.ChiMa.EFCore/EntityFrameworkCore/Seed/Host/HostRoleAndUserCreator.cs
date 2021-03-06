using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using SixMan.ChiMa.Domain.Authorization;
using SixMan.ChiMa.Domain.Authorization.Roles;
using SixMan.ChiMa.Domain.Authorization.Users;
using SixMan.ChiMa.Domain.Zero.Authorization.Users;

namespace SixMan.ChiMa.EFCore.Seed.Host
{
    public class HostRoleAndUserCreator
    {
        private readonly ChiMaDbContext _context;

        public HostRoleAndUserCreator(ChiMaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            // System role and user for host
            CreateRoleAndDefaulUser(StaticRoleNames.Host.System, PermissionNames.System, StaticUserNames.System);

            // Admin role for host

            var adminRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }

            // Admin user for host

            var adminUserForHost = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == AbpUserBase.AdminUserName);
            if (adminUserForHost == null)
            {
                var user = new User
                {
                    TenantId = null,
                    UserName = AbpUserBase.AdminUserName,
                    Name = "admin",
                    Surname = "admin",
                    EmailAddress = "admin@aspnetboilerplate.com",
                    IsEmailConfirmed = true,
                    IsActive = true,
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" // 123qwe
                };

                user.SetNormalizedNames();

                adminUserForHost = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));
                _context.SaveChanges();

                // Grant all permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new ChiMaAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = null,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                _context.SaveChanges();

                // User account of admin user
                _context.UserAccounts.Add(new UserAccount
                {
                    TenantId = null,
                    UserId = adminUserForHost.Id,
                    UserName = AbpUserBase.AdminUserName,
                    EmailAddress = adminUserForHost.EmailAddress
                });

                _context.SaveChanges();
            }
        }

        private void CreateRoleAndDefaulUser(string roleName, string permissionName, string userName )
        {
            // 建role
            var role = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == roleName);
            if (role == null)
            {
                role = _context.Roles.Add(new Role(null, roleName, roleName) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }

            //加用户
            var user = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == userName);
            if (user == null)
            {
                var newUser = new User
                {
                    TenantId = null,
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
            }

                // 设权限
            _context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        TenantId = null,
                        Name = permissionName,
                        IsGranted = true,
                        RoleId = role.Id
                    });
            _context.SaveChanges();

        }
    }
}
