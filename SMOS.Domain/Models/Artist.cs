using Newtonsoft.Json;
using System;

namespace SMOS.Domain.Models
{
    public class Artist
    {
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
