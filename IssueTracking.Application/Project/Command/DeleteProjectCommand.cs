using System;
using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Project.Command
{
    public class DeleteProjectCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
