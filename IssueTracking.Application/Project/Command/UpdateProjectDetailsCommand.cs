using System;
using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Project.Command
{
    public class UpdateProjectDetailsCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }
    }
}
