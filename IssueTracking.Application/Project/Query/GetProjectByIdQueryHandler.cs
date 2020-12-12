using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.DTO;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Project.Query
{
    class GetProjectByIdQueryHandler:IQueryHandler<GetProjectByIdQuery,ProjectDto> 
    {
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly IMapperService _mapperService;

        public GetProjectByIdQueryHandler(
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,IMapperService mapperService)
        {
            _projectRepository = projectRepository;
            _mapperService = mapperService;
        }
        public async Task<ProjectDto> Handle(GetProjectByIdQuery  query, CancellationToken cancellationToken)
        {
            var specification=new ProjectSpecification(query.Id);
            var project = await _projectRepository.GetSingleOrDefaultAsync(specification);
            return new ProjectDto
            {
                Name = project.Name,
                Key = project.Key,
                Issues =project.Issues.Select(_mapperService.MapIssueToIssueDto),
                Owner = _mapperService.MapUserToUserDto(project.Owner),
                Participants = project.Participants.Select(_mapperService.MapUserToUserDto),
                Id = project.Id
            };
        }
    }
}
