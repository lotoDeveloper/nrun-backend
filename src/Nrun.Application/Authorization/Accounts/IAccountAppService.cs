using System.Threading.Tasks;
using Abp.Application.Services;
using Nrun.Authorization.Accounts.Dto;

namespace Nrun.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
