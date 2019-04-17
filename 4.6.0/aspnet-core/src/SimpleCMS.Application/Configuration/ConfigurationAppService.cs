using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SimpleCMS.Configuration.Dto;

namespace SimpleCMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SimpleCMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
