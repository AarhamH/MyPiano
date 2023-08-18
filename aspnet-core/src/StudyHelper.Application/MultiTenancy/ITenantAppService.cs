using Abp.Application.Services;
using StudyHelper.MultiTenancy.Dto;

namespace StudyHelper.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

