using System;
using System.Collections.Generic;
using IssueTracking.Application.DTO;

namespace IssueTracking.Application.Project.Query
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserDto Owner { get; set; }

        public string Key { get; set; }

        public IEnumerable<UserDto> Participants { get; set; }

        public IEnumerable<IssueDto> Issues { get; set; }
    }
}
