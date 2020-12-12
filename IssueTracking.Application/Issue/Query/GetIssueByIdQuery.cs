using IssueTracking.Application.CQRS;
using IssueTracking.Application.DTO;

namespace IssueTracking.Application.Issue.Query
{
    public class GetIssueByIdQuery : IQuery<IssueDto>
    {
        public string Id { get; set; }
    }
}
