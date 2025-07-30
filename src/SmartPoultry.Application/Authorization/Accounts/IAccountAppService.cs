using Abp.Application.Services;
using SmartPoultry.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace SmartPoultry.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
