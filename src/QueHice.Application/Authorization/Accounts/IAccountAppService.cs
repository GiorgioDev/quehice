using System.Threading.Tasks;
using Abp.Application.Services;
using QueHice.Authorization.Accounts.Dto;

namespace QueHice.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
