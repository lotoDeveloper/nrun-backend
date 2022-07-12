using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Nrun.Configuration.Dto;

namespace Nrun.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NrunAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
