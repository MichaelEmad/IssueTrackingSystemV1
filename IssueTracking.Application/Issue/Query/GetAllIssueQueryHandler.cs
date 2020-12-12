using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.DTO;

namespace IssueTracking.Application.Issue.Query
{
   public class GetAllIssueQueryHandler:IQueryHandler<GetAllIssueQuery,IEnumerable<IssueDto>>
    {
        public GetAllIssueQueryHandler()
        {
            
        }
        public Task<IEnumerable<IssueDto>> Handle(GetAllIssueQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
