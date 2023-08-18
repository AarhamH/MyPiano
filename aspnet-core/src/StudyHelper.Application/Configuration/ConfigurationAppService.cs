using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using StudyHelper.Configuration.Dto;

namespace StudyHelper.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : StudyHelperAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
