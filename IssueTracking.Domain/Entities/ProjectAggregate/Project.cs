using System.Collections.Generic;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Entities.UserAggregate;
using IssueTracking.Domain.Interfaces;
using JetBrains.Annotations;

namespace IssueTracking.Domain.Entities.ProjectAggregate
{
    public class Project : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public string Key { get; private set; }

        public int SerialNumber { get; private set; }

        public User Owner { get; private set; }

        public ICollection<Issue> Issues { get; private set; }

        public ICollection<User> Participants { get; private set; }

        private Project()
        {

        }

        public Project([NotNull] string name, [NotNull] string key, [NotNull] User owner)
        {
            Name = name;
            Key = key;
            Owner = owner;
        }

        public void UpdateDetails([NotNull] string name, [NotNull] string key)
        {
            Name = name;
            Key = key;
        }

        public void UpdateProjectIssue(ICollection<Issue> issues)
        {
            Issues = issues;
        }

        public void UpdateProjectParticipants(ICollection<User> participants)
        {
            Participants = participants;
        }
    }
}
