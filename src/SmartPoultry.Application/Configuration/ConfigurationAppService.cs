using Abp.Authorization;
using Abp.Runtime.Session;
using SmartPoultry.Configuration.Dto;
using System.Threading.Tasks;

namespace SmartPoultry.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : SmartPoultryAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
