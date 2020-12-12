using IssueTracking.Domain.Enums;

namespace IssueTracking.Application.DTO
{
    public class IssueDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public UserDto Assignee { get; set; }

        public UserDto Reporter { get; set; }

        public IssueType Type { get; set; }

        public IssueStatus Status { get; set; }
    }
}
