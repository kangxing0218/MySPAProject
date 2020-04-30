using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MySpaProject.Configuration.Dto;

namespace MySpaProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MySpaProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
