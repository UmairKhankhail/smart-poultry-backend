using SmartPoultry.Configuration.Dto;
using System.Threading.Tasks;

namespace SmartPoultry.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
