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

        public int SerialNumber { get; set; }

        public User Owner { get; private set; }

        public ICollection<Issue> Issues { get; private set; }

        public ICollection<User> ParticipantsProjects { get; private set; }

        private Project()
        {

        }

        public Project([NotNull] string name, [NotNull] string key, [NotNull] User owner)
        {
            Name = name;
            Key = key;
            Owner = owner;
        }

        public void UpdateProjectIssue(ICollection<Issue> issues)
        {
            Issues = issues;
        }

        

    }
}
