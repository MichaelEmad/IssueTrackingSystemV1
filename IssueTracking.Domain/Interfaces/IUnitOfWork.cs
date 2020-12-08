using System.Threading.Tasks;

namespace IssueTracking.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
