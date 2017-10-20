using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using SixMan.ChiMa.Domain;

namespace SixMan.ChiMa.Controllers
{
    public abstract class ChiMaControllerBase: AbpController
    {
        protected ChiMaControllerBase()
        {
            LocalizationSourceName = ChiMaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
