using Newtonsoft.Json;

namespace Statistics.Core.Models
{
    public record Error
    {
        public Error() { }

        public Error(string message, string description)
        {
            Message = message;
            Description = description;
        }

        [JsonProperty("Error")]
        public string Message { get; init; }
        public string Description { get; init; }
    }
}
