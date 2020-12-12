using System.Threading;
using System.Threading.Tasks;
using IssueTracking.Application.CQRS;
using IssueTracking.Application.Helpers;
using IssueTracking.Application.Specifications;
using IssueTracking.Domain.Interfaces;

namespace IssueTracking.Application.Issue.Command
{
    public class DeleteIssueCommandHandler : ICommandHandler<DeleteIssueCommand>
    {
        private readonly IRepository<Domain.Entities.IssueAggregate.Issue, string> _issueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIssueCommandHandler(
            IRepository<Domain.Entities.IssueAggregate.Issue, string> issueRepository,
            IUnitOfWork unitOfWork)
        {
            _issueRepository = issueRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteIssueCommand command, CancellationToken cancellationToken)
        {
            var specification = new IssueSpecification(command.IssueId);
            var issue = await _issueRepository.GetSingleOrDefaultAsync(specification);
            Check.NotNull(issue, nameof(issue));
            _issueRepository.Delete(issue);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
