using System;
using System.Threading.Tasks;
using IssueTracking.Application.Issue.Command;
using IssueTracking.Application.Issue.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracking.API.Contollers
{
    [Route("issue")]
    [ApiController]
    [Authorize]
    public class IssueController : Controller
    {
        private readonly IMediator _mediator;

        public IssueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIssues()
        {
            var result = await _mediator.Send(new GetAllIssueQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssue(string id)
        {
            var result = await _mediator.Send(new GetIssueByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}/assignee")]
        public async Task<IActionResult> GetIssueByAssignId(Guid id)
        {
            var result = await _mediator.Send(new GetIssueByAssigneeIdQuery { AssigneeId = id });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateIssue([FromBody]CreateIssueCommand createIssueCommand)
        {
            await _mediator.Publish(
                new CreateIssueCommand
                {
                     ProjectId = createIssueCommand.ProjectId,
                     Description = createIssueCommand.Description,
                     Title = createIssueCommand.Title,
                     Type = createIssueCommand.Type,
                     Status = createIssueCommand.Status,
                });
            return Ok();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateProject(string id,[FromBody] UpdateIssueStatusCommand updateIssueStatusCommand  )
        {
            await _mediator.Publish(
                new UpdateIssueStatusCommand
                {
                    Status = updateIssueStatusCommand.Status,
                    Id = id
                });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var result = await _mediator.Send(new DeleteIssueCommand { IssueId = id });
            return Ok(result);
        }

    }
}
