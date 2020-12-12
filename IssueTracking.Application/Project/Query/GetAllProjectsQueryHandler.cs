using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Project.Query
{
    public class GetAllProjectsQueryHandler:IQueryHandler<GetAllProjectsQuery,IEnumerable<ProjectDto>>
    {
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly IMapperService _mapperService;

        public GetAllProjectsQueryHandler(
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,IMapperService mapperService)
        {
            _projectRepository = projectRepository;
            _mapperService = mapperService;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsQuery query, CancellationToken cancellationToken)
        {
            var specification =new  ProjectSpecification();
            var projects = await _projectRepository.GetAllAsync(specification);
            var mappedProjects = projects.Select(_mapperService.MapProjectToProjectDto).ToArray();
            return mappedProjects;
        }
    }
}
