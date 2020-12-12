using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;
using IssueTracking.Domain.Entities.UserAggregate;

namespace IssueTracking.Application.Specifications
{
    public class UserSpecification:Specification<User>
    {
        public UserSpecification()
        {
            Query.Include(user => user.ProjectsOwner);
        }

        public UserSpecification(string email):this()
        {
            Query.Where(user => user.Email == email);
        }

        public UserSpecification(IEnumerable<string> emails):this()
        {
            Query.Where(user => emails.Contains(user.Email));
        }
    }
}
