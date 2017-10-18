using System.Threading.Tasks;
using SixMan.ChiMa.Configuration.Dto;

namespace SixMan.ChiMa.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
