using Newtonsoft.Json;
using System.Collections.Generic;

namespace SMOS.Domain.Models
{
    public class Playlists
    {
        [JsonProperty("items")]
        public List<Playlist> Items { get; set; }
    }
}
