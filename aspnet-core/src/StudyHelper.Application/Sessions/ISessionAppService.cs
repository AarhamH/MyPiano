using System.Threading.Tasks;
using Abp.Application.Services;
using StudyHelper.Sessions.Dto;

namespace StudyHelper.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
