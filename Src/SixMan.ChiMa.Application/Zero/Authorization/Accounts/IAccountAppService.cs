using System.Threading.Tasks;
using Abp.Application.Services;
using SixMan.ChiMa.Application.Authorization.Accounts.Dto;

namespace SixMan.ChiMa.Application.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
