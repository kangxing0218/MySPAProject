using System.Threading.Tasks;
using Abp.Application.Services;
using MySpaProject.Sessions.Dto;

namespace MySpaProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
