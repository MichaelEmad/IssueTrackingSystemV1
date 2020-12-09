using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IssueTracking.Domain.Entities.UserAggregate
{
    public class User : IdentityUser
    {
        private User()
        {

        }
        public ICollection<ParticipantsProjects> ParticipantsProjects { get; private set; }
    }
}
