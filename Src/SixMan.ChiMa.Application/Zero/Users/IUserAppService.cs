using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixMan.ChiMa.Roles.Dto;
using SixMan.ChiMa.Users.Dto;

namespace SixMan.ChiMa.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
