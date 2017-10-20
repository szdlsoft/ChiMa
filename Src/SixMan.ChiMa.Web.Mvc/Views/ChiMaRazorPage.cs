using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using SixMan.ChiMa.Domain;

namespace SixMan.ChiMa.Web.Views
{
    public abstract class ChiMaRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ChiMaRazorPage()
        {
            LocalizationSourceName = ChiMaConsts.LocalizationSourceName;
        }
    }
}
