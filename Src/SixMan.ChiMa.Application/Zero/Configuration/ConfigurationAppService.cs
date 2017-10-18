using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SixMan.ChiMa.Configuration.Dto;

namespace SixMan.ChiMa.Configuration
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
