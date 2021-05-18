using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using Statistics.Core.Controllers;
using Statistics.Core.Endoints.Team;
using System;
using System.Threading.Tasks;

namespace Statistics.Admin.Controllers
{
    public class TeamController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TeamController(
            ILogger<TeamController> logger,
            IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost("GetAll")]
        [OpenApiOperation(
            operationId: "Team.GetAll",
            summary: "Get teams by filter",
            description: "Get teams by filter"
        )]
        [OpenApiTags("Team")]

        public async Task<IActionResult> GetById([FromBody] GetAllCommand command)
        {
            try
            {
                var teams = await _mediator.Send(command);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }

        [HttpGet("{id:int}")]
        [OpenApiOperation(
            operationId: "Team.Get",
            summary: "Get team by id",
            description: "Get team by id"
        )]
        [OpenApiTags("Team")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var team = await _mediator.Send(new GetCommand() { Id = id });
                return Ok(team);
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }

        [HttpPost]
        [OpenApiOperation(
            operationId: "Team.Create",
            summary: "Create team",
            description: "Create team"
        )]
        [OpenApiTags("Team")]

        public async Task<IActionResult> Create([FromBody] CreateCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }

        [HttpPut]
        [OpenApiOperation(
            operationId: "Team.Update",
            summary: "Update team",
            description: "Update team"
        )]
        [OpenApiTags("Team")]

        public async Task<IActionResult> Update([FromBody] UpdateCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }

        [HttpDelete("{id:int}")]
        [OpenApiOperation(
            operationId: "Team.Delete",
            summary: "Delete team",
            description: "Delete team"
        )]
        [OpenApiTags("Team")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCommand() { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }
    }
}