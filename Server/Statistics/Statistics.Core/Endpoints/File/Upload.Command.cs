using MediatR;
using Microsoft.AspNetCore.Http;
using Statistics.Core.Enums;

namespace Statistics.Core.Endoints.File
{
    public record UploadCommand(IFormFile File, UploadFolder Folder) : IRequest<Unit>;
}
