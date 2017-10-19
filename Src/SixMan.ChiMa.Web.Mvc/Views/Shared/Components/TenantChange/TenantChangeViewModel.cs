using Abp.AutoMapper;
using SixMan.ChiMa.Application.Sessions.Dto;

namespace SixMan.ChiMa.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}