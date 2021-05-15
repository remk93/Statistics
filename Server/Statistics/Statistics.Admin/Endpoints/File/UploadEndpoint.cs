using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using Statistics.Core.Controllers;
using Statistics.Core.Modules.File;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Admin.Endpoints.File
{
    public class UploadEndpoint : BaseApiController
    {
        private readonly IMediator _mediator;

        public UploadEndpoint(
            ILogger<UploadEndpoint> logger,
            IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [OpenApiOperation(
            operationId: "File.Upload",
            summary: "Upload file",
            description: "Upload file"
        )]
        [OpenApiTags("File")]

        public async Task<IActionResult> Upload([FromForm]UploadCommand command)
        {
            try
            {
                await _mediator.Send(command, new CancellationTokenSource().Token);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }
    }
}
