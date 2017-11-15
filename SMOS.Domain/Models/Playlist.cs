using Newtonsoft.Json;
using System;

namespace SMOS.Domain.Models
{
    public class Playlist
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("owner")]
        public PublicProfile Owner { get; set; }
    }
}
