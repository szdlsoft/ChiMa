using System.Threading.Tasks;
using SixMan.ChiMa.Application.Configuration.Dto;

namespace SixMan.ChiMa.Application.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
