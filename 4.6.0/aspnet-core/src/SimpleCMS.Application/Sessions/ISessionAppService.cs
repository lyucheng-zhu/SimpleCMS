using System.Threading.Tasks;
using Abp.Application.Services;
using SimpleCMS.Sessions.Dto;

namespace SimpleCMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
