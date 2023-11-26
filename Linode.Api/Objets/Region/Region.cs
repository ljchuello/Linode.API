using System.Collections.Generic;
using Newtonsoft.Json;

namespace Linode.Api.Objets.Region
{
    public class Region
    {
        /// <summary>
        /// Gets or sets the unique ID of this Region.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets detailed location information for this Region, including city, state or region, and country.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the country where this Region resides.
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a list of capabilities of this region.
        /// </summary>
        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Capabilities { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets this region’s current operational status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets DNS resolver information for this region.
        /// </summary>
        [JsonProperty("resolvers", NullValueHandling = NullValueHandling.Ignore)]
        public Resolvers Resolvers { get; set; } = new Resolvers();
    }

    public class Resolvers
    {
        /// <summary>
        /// Gets or sets the IPv4 addresses for this region’s DNS resolvers, separated by commas.
        /// </summary>
        [JsonProperty("ipv4", NullValueHandling = NullValueHandling.Ignore)]
        public string Ipv4 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the IPv6 addresses for this region’s DNS resolvers, separated by commas.
        /// </summary>
        [JsonProperty("ipv6", NullValueHandling = NullValueHandling.Ignore)]
        public string Ipv6 { get; set; } = string.Empty;
    }
}
