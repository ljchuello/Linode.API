using Newtonsoft.Json;
using System.Collections.Generic;

namespace Linode.Api.Objets.LinodeType.Get
{
    public class Response
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<LinodeType> Data { get; set; } = new List<LinodeType>();

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long Page { get; set; } = 0;

        [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
        public long Pages { get; set; } = 0;

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public long Results { get; set; } = 0;
    }
}
