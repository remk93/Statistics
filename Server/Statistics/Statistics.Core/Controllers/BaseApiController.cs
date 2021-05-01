using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Statistics.Core.Exceptions;
using Statistics.Core.Models;
using System;
using System.Linq;

namespace Statistics.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly ILogger<BaseApiController> _logger;

        public BaseApiController(ILogger<BaseApiController> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleExceptionResult(Exception ex)
        {
            if (ex is BadRequestException)
            {
                return BadRequest(new Error("Incorrect Request", ex.Message));
            }
            else if (ex is NotFoundException)
            {
                return NotFound(new Error("Data was not found", ex.Message));
            }
            else if (ex is ValidationException)
            {
                return BadRequest(new Error("Invalid Data", ex.Message));
            }
            else
            {
                return UnhandledErrorException(ex);
            }
        }

        protected Error GetValidationError(ValidationResult validationResult)
        {
            var descrition = validationResult.Errors.Select(x => x.ErrorMessage).First();
            _logger.LogInformation($"Validation error: {descrition}");

            var error = new Error("Validtion Issue", descrition);

            return error;
        }

        private IActionResult UnhandledErrorException(Exception ex)
        {
            _logger.LogInformation(ex, $"Unhandled Error: {ex.Message}");

            var error = new Error()
            {
                Message = "Unhandled Error",
                Description = ex.Message
            };

            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }
}