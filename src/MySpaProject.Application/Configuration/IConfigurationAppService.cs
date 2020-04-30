using System.Threading.Tasks;
using MySpaProject.Configuration.Dto;

namespace MySpaProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
