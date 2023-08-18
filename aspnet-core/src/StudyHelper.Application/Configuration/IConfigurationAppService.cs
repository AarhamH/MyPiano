using System.Threading.Tasks;
using StudyHelper.Configuration.Dto;

namespace StudyHelper.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
