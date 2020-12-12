using System;
using System.Threading.Tasks;
using IssueTracking.Application.Project.Command;
using IssueTracking.Application.Project.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracking.API.Contollers
{
    [Route("project")]
    [ApiController]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            var result = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject(CreateProjectCommand createProjectCommand)
        {
            await _mediator.Publish(
                new CreateProjectCommand
                {
                    Key = createProjectCommand.Key.ToUpper(),
                    Name = createProjectCommand.Name
                });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] UpdateProjectDetailsCommand updateProjectDetails)
        {
            await _mediator.Publish(
                new UpdateProjectDetailsCommand()
                {
                    Id = id,
                    Key = updateProjectDetails.Key.ToUpper(),
                    Name = updateProjectDetails.Name
                });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand { Id = id });
            return Ok(result);
        }

        [HttpPut("{id}/participant")]
        public async Task<IActionResult> AddNewParticipant(Guid id,[FromBody]UpdateProjectParticipantsCommand updateProjectParticipants)
        {
            await _mediator.Publish(
                new UpdateProjectParticipantsCommand
                {
                    Id = id,
                    Participants = updateProjectParticipants.Participants
                });
            return Ok();
        }
    }
}
