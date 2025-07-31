using System.Threading.Tasks;
using Abp.Application.Services;
using SmartPoultry.Authorization.Accounts.Dto;

namespace SmartPoultry.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
