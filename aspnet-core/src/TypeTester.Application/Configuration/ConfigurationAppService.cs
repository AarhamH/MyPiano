using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TypeTester.Configuration.Dto;

namespace TypeTester.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TypeTesterAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
