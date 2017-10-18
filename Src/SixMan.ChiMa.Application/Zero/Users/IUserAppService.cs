using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Application.Roles.Dto;
using SixMan.ChiMa.Application.Users.Dto;

namespace SixMan.ChiMa.Application.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
