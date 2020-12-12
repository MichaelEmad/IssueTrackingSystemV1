using IssueTracking.Application.DTO;
using IssueTracking.Application.Project.Query;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Entities.UserAggregate;

namespace IssueTracking.Application.Interfaces
{
    public interface IMapperService
    {
        public UserDto MapUserToUserDto(User user);

        public ProjectDto MapProjectToProjectDto(Domain.Entities.ProjectAggregate.Project project);

        public IssueDto MapIssueToIssueDto(Domain.Entities.IssueAggregate.Issue issue);
    }
}
