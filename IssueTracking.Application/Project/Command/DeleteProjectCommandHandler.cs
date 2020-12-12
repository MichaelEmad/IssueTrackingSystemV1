using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Exceptions;
using IssueTracking.Application.Helpers;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Project.Command
{
    public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
    {
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
        {
            var projectSpecification = new ProjectSpecification(command.Id);
            var project = await _projectRepository.GetSingleOrDefaultAsync(projectSpecification);
            Check.NotNull(project, nameof(project));
            if (project.Owner.Id != _currentUserService.UserId)
            {
               throw  new UserException("Sorry You Cant not delete this project");
            }
            _projectRepository.Delete(project);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
