using System;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Exceptions;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Project.Command
{
    class UpdateProjectDetailsCommandHandler:ICommandHandler<UpdateProjectDetailsCommand>
    {
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectDetailsCommandHandler(
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateProjectDetailsCommand command, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(command.Id);
            if (project is null)
            {
                throw new UserException("sorry there no project has this ID");
            }
            project.UpdateDetails(command.Name,command.Key);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
