using System.Threading.Tasks;
using Abp.AutoMapper;
using SixMan.ChiMa.Application.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace SixMan.ChiMa.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : ChiMaViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public TenantChangeViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = loginInfo.MapTo<TenantChangeViewModel>();
            return View(model);
        }
    }
}
