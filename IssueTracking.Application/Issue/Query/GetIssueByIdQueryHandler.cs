using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.DTO;
using IssueTracking.Application.Helpers;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Issue.Query
{
    public class GetIssueByIdQueryHandler : IQueryHandler<GetIssueByIdQuery, IssueDto>
    {
        private readonly IRepository<Domain.Entities.IssueAggregate.Issue, string> _issueRepository;
        private readonly IMapperService _mapperService;

        public GetIssueByIdQueryHandler(
            IRepository<Domain.Entities.IssueAggregate.Issue, string> issueRepository, 
            IMapperService mapperService)
        {
            _issueRepository = issueRepository;
            _mapperService = mapperService;
        }
        public async Task<IssueDto> Handle(GetIssueByIdQuery query, CancellationToken cancellationToken)
        {
             var specification=new IssueSpecification(query.Id);
             var issue = await _issueRepository.GetSingleOrDefaultAsync(specification);
             Check.NotNull(issue, nameof(issue));
             return new IssueDto
             {
                 Title = issue.Title,
                 Description = issue.Title,
                 Assignee = _mapperService.MapUserToUserDto(issue.Assignee),
                 Status = issue.Status,
                 Type = issue.Type,
                 Reporter = _mapperService.MapUserToUserDto(issue.Reporter)
             };
        }
    }
}
