using System.Threading.Tasks;
using Nrun.Configuration.Dto;

namespace Nrun.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
