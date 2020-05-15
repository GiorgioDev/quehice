using System.Threading.Tasks;
using QueHice.Configuration.Dto;

namespace QueHice.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
