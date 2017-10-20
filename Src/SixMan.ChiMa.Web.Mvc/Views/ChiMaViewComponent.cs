using Abp.AspNetCore.Mvc.ViewComponents;
using SixMan.ChiMa.Domain;

namespace SixMan.ChiMa.Web.Views
{
    public abstract class ChiMaViewComponent : AbpViewComponent
    {
        protected ChiMaViewComponent()
        {
            LocalizationSourceName = ChiMaConsts.LocalizationSourceName;
        }
    }
}