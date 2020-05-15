using Abp.Application.Services;
using QueHice.MultiTenancy.Dto;

namespace QueHice.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

