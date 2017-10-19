using System.Linq;
using System.Threading.Tasks;
using Abp.Configuration;
using SixMan.ChiMa.Application.Configuration;
using SixMan.ChiMa.Application.Configuration.Ui;
using Microsoft.AspNetCore.Mvc;
using SixMan.ChiMa.Domain.Configuration;

namespace SixMan.ChiMa.Web.Views.Shared.Components.RightSideBar
{
    public class RightSideBarViewComponent : ChiMaViewComponent
    {
        private readonly ISettingManager _settingManager;

        public RightSideBarViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var themeName = await _settingManager.GetSettingValueAsync(AppSettingNames.UiTheme);

            var viewModel = new RightSideBarViewModel
            {
                CurrentTheme = UiThemes.All.FirstOrDefault(t => t.CssClass == themeName)
            };

            return View(viewModel);
        }
    }
}
