using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.MultiTenancy.Dto;

namespace SixMan.ChiMa.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
