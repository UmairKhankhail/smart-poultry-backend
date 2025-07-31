using System.Threading.Tasks;
using Abp.Application.Services;
using SmartPoultry.Sessions.Dto;

namespace SmartPoultry.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
