using Newtonsoft.Json;

namespace SMOS.Domain.Models
{
    public class Track
    {
        [JsonProperty("track")]
        public FullTrack FullTrack { get; set; }
    }
}
