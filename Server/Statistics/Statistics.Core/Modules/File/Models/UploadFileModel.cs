using Microsoft.AspNetCore.Http;
using Statistics.Core.Enums;

namespace Statistics.Core.Modules.File.Models
{
    public class UploadFileModel
    {
        public IFormFile File { get; set; }
        public UploadFolder Folder { get; set; }
    }
}
