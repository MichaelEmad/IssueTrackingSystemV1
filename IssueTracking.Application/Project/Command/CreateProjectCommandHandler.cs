using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Interfaces;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Project.Command
{
    class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand>
    {
        private readonly IRepository<Domain.Entities.ProjectAggregate.Project> _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public CreateProjectCommandHandler(
            IRepository<Domain.Entities.ProjectAggregate.Project> projectRepository,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }
        public async Task Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var project =
                new Domain.Entities.ProjectAggregate.Project(command.Name, command.Key, _currentUserService.User);
            _projectRepository.Add(project);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
