using System;
using System.Collections.Generic;
using IssueTracking.Domain.Entities.ProjectAggregate;
using IssueTracking.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IssueTracking.Domain.Entities.UserAggregate
{
    public class User : IdentityUser<Guid>,IAggregateRoot,IEntity
    {
        public User()
        {
             Id=Guid.NewGuid();
        }

        public ICollection<Project> ProjectsOwner { get; set; }
        public ICollection<Project> Projects { get; private set; }
    }
}
