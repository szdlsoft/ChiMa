using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Roles.Dto;

namespace SixMan.ChiMa.Application.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
