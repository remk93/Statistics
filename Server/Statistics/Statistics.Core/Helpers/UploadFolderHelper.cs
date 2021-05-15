using Statistics.Core.Enums;
using static Statistics.Core.Constants.Constants;

namespace Statistics.Core.Helpers
{
    public class UploadFolderHelper
    {
        public static string GetModuleFolder(UploadFolder module) =>
            module switch
            {
                UploadFolder.Team => UploadFolders.Team,

                _ => UploadFolders.Upload
            };
    }
}
