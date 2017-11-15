using Newtonsoft.Json;
using System;

namespace SMOS.Domain.Models
{
    public class PublicProfile
    {
        [JsonProperty("id")]
        public String Id { get; set; }
    }
}
