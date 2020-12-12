using System;
using IssueTracking.Domain.Entities.UserAggregate;

namespace IssueTracking.Application.Interfaces
{
    public interface ICurrentUserService
    {
        public Guid UserId { get; }

        public string UserEmail { get; }

        public User User { get; }
    }
}
