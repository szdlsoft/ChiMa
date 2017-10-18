using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SixMan.ChiMa.Application.Configuration.Dto;
using SixMan.ChiMa.Domain.Configuration;

namespace SixMan.ChiMa.Application.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ChiMaAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
