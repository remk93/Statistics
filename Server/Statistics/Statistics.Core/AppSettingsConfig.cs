using Microsoft.Extensions.Configuration;

namespace Statistics.Core
{
    public static class AppSettingsConfig
    {
        private static readonly IConfiguration _configuration;

        static AppSettingsConfig()
        {
            _configuration = LoadConfiguration();
        }

        public static IConfiguration LoadConfiguration()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            return configuration;
        }

        //public static string UploadsFolder => _configuration.GetSection("StorageOptions:Uploads").Value ??
        //    throw new ArgumentNullException("Configuration of upload folder was not found");
    }
}
