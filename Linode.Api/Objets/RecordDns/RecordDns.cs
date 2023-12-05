using System;
using Linode.Api.Enums;
using Newtonsoft.Json;

namespace Linode.Api.Objets.RecordDns
{
    public class RecordDns
    {
        /// <summary>
        /// This Record’s unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// The type of Record this is in the DNS system. For example, A records associate a domain name with an IPv4 address, and AAAA records associate a domain name with an IPv6 address. For more information, see the guides on DNS Record Types.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public RecordDnsType Type { get; set; } = RecordDnsType.A;

        /// <summary>
        /// The name of this Record. For requests, this property’s actual usage and whether it is required depends on the type of record this represents
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The target for this Record. For requests, this property’s actual usage and whether it is required depends on the type of record this represents
        /// </summary>
        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; } = string.Empty;

        /// <summary>
        /// The priority of the target host for this Record. Lower values are preferred. Only valid for MX and SRV record requests. Required for SRV record requests
        /// </summary>
        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public long Priority { get; set; } = 0;

        /// <summary>
        /// The relative weight of this Record used in the case of identical priority. Higher values are preferred. Only valid and required for SRV record requests.
        /// </summary>
        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public long Weight { get; set; } = 0;

        /// <summary>
        /// The port this Record points to. Only valid and required for SRV record requests.
        /// </summary>
        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public long Port { get; set; } = 0;

        /// <summary>
        /// The name of the service. An underscore (_) is prepended and a period (.) is appended automatically to the submitted value for this property. Only valid and required for SRV record requests.
        /// </summary>
        [JsonProperty("service", NullValueHandling = NullValueHandling.Ignore)]
        public string Service { get; set; } = string.Empty;

        /// <summary>
        /// The protocol this Record’s service communicates with. An underscore (_) is prepended automatically to the submitted value for this property. Only valid for SRV record requests.
        /// </summary>
        [JsonProperty("protocol", NullValueHandling = NullValueHandling.Ignore)]
        public string Protocol { get; set; } = string.Empty;

        /// <summary>
        /// “Time to Live” - the amount of time in seconds that this Domain’s records may be cached by resolvers or other domain servers. Valid values are 300, 3600, 7200, 14400, 28800, 57600, 86400, 172800, 345600, 604800, 1209600, and 2419200 - any other value will be rounded to the nearest valid value.
        /// </summary>
        [JsonProperty("ttl_sec", NullValueHandling = NullValueHandling.Ignore)]
        public long TtlSec { get; set; } = 0;

        /// <summary>
        /// The target for this Record. For requests, this property’s actual usage and whether it is required depends on the type of record this represents
        /// </summary>
        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; } = string.Empty;

        /// <summary>
        /// When this Domain Record was created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// When this Domain Record was last updated.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Updated { get; set; } = new DateTime(1900, 1, 1);
    }
}
