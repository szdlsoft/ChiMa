using System.Threading.Tasks;
using Abp.Application.Services;
using SixMan.ChiMa.Application.Sessions.Dto;

namespace SixMan.ChiMa.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
