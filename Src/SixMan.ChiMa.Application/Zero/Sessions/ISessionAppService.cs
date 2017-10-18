using System.Threading.Tasks;
using Abp.Application.Services;
using SixMan.ChiMa.Sessions.Dto;

namespace SixMan.ChiMa.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
