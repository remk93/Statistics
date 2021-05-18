using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using Statistics.Core.Controllers;
using Statistics.Core.Endoints.File;
using System;
using System.Threading.Tasks;

namespace Statistics.Admin.Endpoints.File
{
    public class UploadController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UploadController(
            ILogger<UploadController> logger,
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
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleExceptionResult(ex);
            }
        }
    }
}
