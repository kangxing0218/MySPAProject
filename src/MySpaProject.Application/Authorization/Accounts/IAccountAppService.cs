using System.Threading.Tasks;
using Abp.Application.Services;
using MySpaProject.Authorization.Accounts.Dto;

namespace MySpaProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
