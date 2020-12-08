using System.Threading.Tasks;

namespace IssueTracking.Application.Interfaces
{
    interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

      
    }
}
