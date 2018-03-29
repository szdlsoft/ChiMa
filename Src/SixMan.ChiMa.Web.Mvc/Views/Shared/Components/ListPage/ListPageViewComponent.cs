using System.Linq;
using System.Threading.Tasks;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SixMan.ChiMa.Web.Views.Shared.Components.ListPage
{
    public class ListPageViewComponent : ChiMaViewComponent
    {
        
        public Task<IViewComponentResult> InvokeAsync(ModelMetadata Meta)
        {
            var model = new ListPageViewModel
            {
               Meta = Meta
            };

            return Task.FromResult(View(model) as IViewComponentResult);
        }
    }
}
