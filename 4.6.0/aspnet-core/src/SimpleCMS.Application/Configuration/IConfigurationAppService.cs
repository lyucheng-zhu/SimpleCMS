using System.Threading.Tasks;
using SimpleCMS.Configuration.Dto;

namespace SimpleCMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
