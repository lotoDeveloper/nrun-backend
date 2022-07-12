using System.Threading.Tasks;
using Abp.Application.Services;
using Nrun.Sessions.Dto;

namespace Nrun.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
