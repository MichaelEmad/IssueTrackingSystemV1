using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Project.Command
{
    class UpdateProjectParticipantsCommandHandler:ICommandHandler<UpdateProjectParticipantsCommand>
    {
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly IRepository<User> _useRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectParticipantsCommandHandler(
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,
            IRepository<User> useRepository,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _useRepository = useRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateProjectParticipantsCommand command, CancellationToken cancellationToken)
        {
            var specification=new UserSpecification(command.Participants);
            var users = await _useRepository.GetAllAsync(specification);
            var projectSpecification=new ProjectSpecification(command.Id);
            var project = await _projectRepository.GetSingleOrDefaultAsync(projectSpecification);
            var existingParticipant = project.Participants.Select(user => user).ToArray();
            var newParticipants = users.Except(existingParticipant).ToArray();
            var deletedParticipants = existingParticipant.Except(users).ToArray();
            var participants = existingParticipant.Except(deletedParticipants).Concat(newParticipants).ToArray();
            project.UpdateProjectParticipants(participants);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
