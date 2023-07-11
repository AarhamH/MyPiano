using Abp.Application.Services;
using TypeTester.MultiTenancy.Dto;

namespace TypeTester.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

