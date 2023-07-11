using System.Threading.Tasks;
using Abp.Application.Services;
using TypeTester.Sessions.Dto;

namespace TypeTester.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
