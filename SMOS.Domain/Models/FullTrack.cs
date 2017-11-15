using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SMOS.Domain.Models
{
    public class FullTrack
    {
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
