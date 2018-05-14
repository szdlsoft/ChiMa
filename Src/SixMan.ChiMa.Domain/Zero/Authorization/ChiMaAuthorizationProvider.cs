using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace SixMan.ChiMa.Domain.Authorization
{
    public class ChiMaAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.System, L("System"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ChiMaConsts.LocalizationSourceName);
        }
    }
}
