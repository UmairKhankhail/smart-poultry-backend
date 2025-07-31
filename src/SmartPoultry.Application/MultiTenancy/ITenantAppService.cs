using Abp.Application.Services;
using SmartPoultry.MultiTenancy.Dto;

namespace SmartPoultry.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

