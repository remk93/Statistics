using MediatR;
using Microsoft.AspNetCore.Http;
using Statistics.Core.Enums;

namespace Statistics.Core.Modules.File
{
    public record UploadCommand(IFormFile File, UploadFolder Folder) : IRequest<Unit>;
}
