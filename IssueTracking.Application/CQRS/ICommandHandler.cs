using MediatR;

namespace IssueTracking.Application.CQRS
{
    public interface ICommandHandler<in TCommand> : INotificationHandler<TCommand>
        where TCommand : ICommand
    {
    }
}
