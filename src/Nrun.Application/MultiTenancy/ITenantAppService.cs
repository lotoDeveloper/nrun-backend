using Abp.Application.Services;
using Nrun.MultiTenancy.Dto;

namespace Nrun.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

