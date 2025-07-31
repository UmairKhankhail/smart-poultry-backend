using System.Threading.Tasks;
using SmartPoultry.Configuration.Dto;

namespace SmartPoultry.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
