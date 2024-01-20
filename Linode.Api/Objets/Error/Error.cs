using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Linode.Api.Objets.Error
{
    public class Root
    {
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;

        public class Error
        {
            [JsonPropertyName("errors")]
            public List<Root> Errors { get; set; }
        }
    }
}
