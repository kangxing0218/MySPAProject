using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MySpaProject.MultiTenancy.Dto;

namespace MySpaProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

