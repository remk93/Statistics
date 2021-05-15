using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Statistics.Core.Enums;
using Statistics.Core.Exceptions;
using Statistics.Core.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Core.Modules.File
{
    public class UploadHandler : IRequestHandler<UploadCommand, Unit>
    {
        private readonly ILogger<UploadHandler> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public static readonly IList<string> AllowFileExtensions = new List<string> { ".png", ".svg", "jpg", "jpeg" };

        public UploadHandler(
        ILogger<UploadHandler> logger,
        IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Unit> Handle(UploadCommand command, CancellationToken cancellationToken)
        {
            var fileExtension = Path.GetExtension(command.File.FileName);
            if (!AllowFileExtensions.Contains(fileExtension?.ToLower()))
            {
                throw new BadRequestException($"File with extention {fileExtension} is not supported");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, UploadFolderHelper.GetModuleFolder(command.Folder), command.File.FileName);
            using Stream fileStream = new FileStream(path, FileMode.Create);

            await command.File.CopyToAsync(fileStream, cancellationToken);

            await fileStream.FlushAsync(cancellationToken);
            await fileStream.DisposeAsync();

            return Unit.Value;
        }

        public void CreateDirectory(UploadFolder folder)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, UploadFolderHelper.GetModuleFolder(folder));
            if (!Directory.Exists(path))
            {
                using (new LogStopwatcher(t => _logger.LogInformation($"Directories were created by path:'{path}' in {t}")))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
