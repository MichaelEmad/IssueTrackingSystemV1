using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Helpers;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Issue.Command
{
    public class UpdateIssueDetailsCommandHandler : ICommandHandler<UpdateIssueDetailsCommand>
    {
        private readonly IRepository<Domain.Entities.IssueAggregate.Issue, string> _issueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIssueDetailsCommandHandler(
            IRepository<Domain.Entities.IssueAggregate.Issue, string> issueRepository,
            IUnitOfWork unitOfWork)
        {
            _issueRepository = issueRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateIssueDetailsCommand command, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetByIdAsync(command.Id);
            Check.NotNull(issue, nameof(issue));
            issue.UpdateIssueDetails(command.Type, command.Title, command.Description);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
