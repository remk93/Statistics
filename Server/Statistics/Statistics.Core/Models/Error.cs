using Newtonsoft.Json;

namespace Statistics.Core.Models
{
    public class Error
    {
        public Error() { }

        public Error(string message, string description)
        {
            Message = message;
            Description = description;
        }

        [JsonProperty("Error")]
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
