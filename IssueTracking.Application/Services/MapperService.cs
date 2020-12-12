using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IssueTracking.Application.DTO;
using IssueTracking.Application.Interfaces;
using IssueTracking.Application.Project.Query;
using IssueTracking.Domain.Entities.IssueAggregate;
using IssueTracking.Domain.Entities.UserAggregate;

namespace IssueTracking.Application.Services
{
    public class MapperService:IMapperService
    {
        public UserDto MapUserToUserDto(User user)
        {
            if (user is null)
            {
                return null;
            }
            return new UserDto
            {
                Email = user.Email,
                Name = user.UserName
            };
        }

        public ProjectDto MapProjectToProjectDto(Domain.Entities.ProjectAggregate.Project project)
        {
            if (project is null)
            {
                return null;
            }
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Key = project.Key,
                Issues = project.Issues.Select(MapIssueToIssueDto),
                Participants = project.Participants.Select(MapUserToUserDto),
                Owner = MapUserToUserDto(project.Owner)
            };
        }

        public IssueDto MapIssueToIssueDto(Domain.Entities.IssueAggregate.Issue issue)
        {
            if (issue is null)
            {
                return null;
            }
            return new IssueDto
            {
                Title = issue.Title,
                Type = issue.Type,
                Status = issue.Status,
                Assignee = MapUserToUserDto(issue.Assignee),
                Description = issue.Description
            };
        }
    }
}
