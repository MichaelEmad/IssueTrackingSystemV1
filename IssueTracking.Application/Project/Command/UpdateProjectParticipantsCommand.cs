using System;
using System.Collections.Generic;
using IssueTracking.Application.CQRS;

namespace IssueTracking.Application.Project.Command
{
    public class UpdateProjectParticipantsCommand : ICommand
    {
        public Guid Id { get; set; }

        public IEnumerable<string> Participants { get; set; }
    }
}
