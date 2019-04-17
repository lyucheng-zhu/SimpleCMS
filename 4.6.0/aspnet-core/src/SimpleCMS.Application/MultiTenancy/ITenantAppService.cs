using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SimpleCMS.MultiTenancy.Dto;

namespace SimpleCMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

