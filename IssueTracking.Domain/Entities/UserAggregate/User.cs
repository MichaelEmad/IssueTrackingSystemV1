using System;
using System.Collections.Generic;
using IssueTracking.Domain.Entities.ProjectAggregate;
using Microsoft.AspNetCore.Identity;

namespace IssueTracking.Domain.Entities.UserAggregate
{
    public class User : IdentityUser<Guid>
    {
        private User()
        {

        }

        public Project Project { get; set; }
        public ICollection<Project> ParticipantsProjects { get; private set; }
    }
}
