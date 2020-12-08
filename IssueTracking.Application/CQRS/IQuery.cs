using MediatR;

namespace IssueTracking.Application.CQRS
{
    public interface IQuery<TQueryResult> : IRequest<TQueryResult>
    {
    }
}
