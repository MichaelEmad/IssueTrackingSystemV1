using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Helpers;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Issue.Command
{
    class CreateIssueCommandHandler:ICommandHandler<CreateIssueCommand>
    {
        private readonly IRepository<Domain.Entities.IssueAggregate.Issue, string> _issueRepository;
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateIssueCommandHandler(
            IRepository<Domain.Entities.IssueAggregate.Issue,string> issueRepository,
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            _issueRepository = issueRepository;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateIssueCommand command, CancellationToken cancellationToken)
        {
            var projectSpecification = new ProjectSpecification(command.ProjectId);
            var project = await _projectRepository.GetSingleOrDefaultAsync(projectSpecification);
            Check.NotNull(project,nameof(project));
            string issueId = (project.Issues.Count() + 1).ToString() + project.Key.ToUpper();
            var issue = new Domain.Entities.IssueAggregate.Issue(
                issueId,
                command.Type,
                command.Title,
                command.Description,
                _currentUserService.User,
                project, command.Status);
            _issueRepository.Add(issue);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
