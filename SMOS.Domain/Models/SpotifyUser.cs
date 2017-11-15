using Newtonsoft.Json;
using System;

namespace SMOS.Domain.Models
{
    public class SpotifyUser
    {
        [JsonProperty("id")]
        public string UserId { get; set; }
        [JsonProperty("display_name")]
        public String DisplayName { get; set; }
    }
}
