using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Statistics.Core.Helpers;
using System.IO;

namespace Statistics.Core.Modules.File
{
    public class UploadCommandValidator : AbstractValidator<UploadCommand>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadCommandValidator(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            RuleFor(x => x.File).NotNull().WithMessage("File was not attached");
            RuleFor(x => x).Must(NotExist).WithMessage("File has already exist");
        }

        private bool NotExist(UploadCommand command)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, UploadFolderHelper.GetModuleFolder(command.Folder), command.File.FileName);
            return System.IO.File.Exists(path);
        }
    }
}
