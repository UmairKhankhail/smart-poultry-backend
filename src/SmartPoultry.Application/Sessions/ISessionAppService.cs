using Abp.Application.Services;
using SmartPoultry.Sessions.Dto;
using System.Threading.Tasks;

namespace SmartPoultry.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
