using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Helpers;
using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Issue.Command
{
    public class UpdateIssueAssigneeCommandHandler : ICommandHandler<UpdateIssueAssigneeCommand>
    {
        private readonly IRepository<Domain.Entities.IssueAggregate.Issue, string> _issueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public UpdateIssueAssigneeCommandHandler(
            IRepository<Domain.Entities.IssueAggregate.Issue, string> issueRepository,
            IUnitOfWork unitOfWork,
            IRepository<User> userRepository)
        {
            _issueRepository = issueRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task Handle(UpdateIssueAssigneeCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.Assignee);
            Check.NotNull(user, nameof(user));
            var issue = await _issueRepository.GetByIdAsync(command.Id);
            Check.NotNull(issue, nameof(issue));
            issue.UpdateAssignee(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
