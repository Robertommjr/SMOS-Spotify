using Newtonsoft.Json;
using System.Collections.Generic;

namespace SMOS.Domain.Models
{
    public class Tracks
    {
        [JsonProperty("items")]
        public List<Track> Items { get; set; }
    }
}
