using System.Threading.Tasks;
using TypeTester.Configuration.Dto;

namespace TypeTester.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
