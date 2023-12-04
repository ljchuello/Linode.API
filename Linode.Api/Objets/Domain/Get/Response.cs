using System.Collections.Generic;
using Newtonsoft.Json;

namespace Linode.Api.Objets.Domain.Get
{
    public class Response
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Domain> Data { get; set; } = new List<Domain>();

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long Page { get; set; } = 0;

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public long Pages { get; set; } = 0;

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long Results { get; set; } = 0;
    }
}
