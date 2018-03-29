using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.MultiTenancy.Dto;

namespace SixMan.ChiMa.Application.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
