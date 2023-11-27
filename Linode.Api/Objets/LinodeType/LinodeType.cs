using Newtonsoft.Json;
using System.Collections.Generic;

namespace Linode.Api.Objets.LinodeType
{
    public class LinodeType
    {
        /// <summary>
        /// Linode ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Linode label.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Default cost of provisioning this Linode Type.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public Price Price { get; set; } = new Price();

        /// <summary>
        /// Region-specific prices for this Linode Type.
        /// </summary>
        [JsonProperty("region_prices", NullValueHandling = NullValueHandling.Ignore)]
        public List<RegionPrice> RegionPrices { get; set; } = new List<RegionPrice>();

        /// <summary>
        /// Optional additional services and their associated costs for Linodes.
        /// </summary>
        [JsonProperty("addons", NullValueHandling = NullValueHandling.Ignore)]
        public Addons Addons { get; set; } = new Addons();

        /// <summary>
        /// Amount of RAM included in this Linode Type.
        /// </summary>
        [JsonProperty("memory", NullValueHandling = NullValueHandling.Ignore)]
        public long Memory { get; set; } = 0;

        /// <summary>
        /// Disk size in MB of this Linode Type.
        /// </summary>
        [JsonProperty("disk", NullValueHandling = NullValueHandling.Ignore)]
        public long Disk { get; set; } = 0;

        /// <summary>
        /// Monthly outbound transfer amount in MB for this Linode Type.
        /// </summary>
        [JsonProperty("transfer", NullValueHandling = NullValueHandling.Ignore)]
        public long Transfer { get; set; } = 0;

        /// <summary>
        /// Number of VCPU cores this Linode Type offers.
        /// </summary>
        [JsonProperty("vcpus", NullValueHandling = NullValueHandling.Ignore)]
        public long Vcpus { get; set; } = 0;

        /// <summary>
        /// Number of GPUs this Linode Type offers.
        /// </summary>
        [JsonProperty("gpus", NullValueHandling = NullValueHandling.Ignore)]
        public long Gpus { get; set; } = 0;

        /// <summary>
        /// Outbound bandwidth allocation in Mbits for this Linode Type.
        /// </summary>
        [JsonProperty("network_out", NullValueHandling = NullValueHandling.Ignore)]
        public long NetworkOut { get; set; } = 0;

        /// <summary>
        /// Class of the Linode Type.
        /// </summary>
        [JsonProperty("class", NullValueHandling = NullValueHandling.Ignore)]
        public string Class { get; set; } = string.Empty;

        /// <summary>
        /// Linode Type that a mutate will upgrade to for a Linode of this type. If "null", a Linode of this type may not mutate.
        /// </summary>
        [JsonProperty("successor", NullValueHandling = NullValueHandling.Ignore)]
        public string Successor { get; set; } = string.Empty;
    }

    public class Price
    {
        /// <summary>
        /// Cost per hour to add Backups service.
        /// </summary>
        [JsonProperty("hourly", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Hourly { get; set; } = 0;

        /// <summary>
        /// Cost per month to add Backups service.
        /// </summary>
        [JsonProperty("monthly", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Monthly { get; set; } = 0;
    }

    public class RegionPrice
    {
        /// <summary>
        /// Region ID for these prices.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Cost per hour to add Backups service in this Region.
        /// </summary>
        [JsonProperty("hourly", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Hourly { get; set; } = 0;

        /// <summary>
        /// Cost per month to add Backups service in this Region.
        /// </summary>
        [JsonProperty("monthly", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Monthly { get; set; } = 0;
    }

    public class Addons
    {
        /// <summary>
        /// Information about the optional Backup service offered for Linodes.
        /// </summary>
        [JsonProperty("backups", NullValueHandling = NullValueHandling.Ignore)]
        public Backups Backups { get; set; } = new Backups();
    }

    public class Backups
    {
        /// <summary>
        /// Default cost of enabling Backups for this Linode Type.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public Price Price { get; set; } = new Price();

        /// <summary>
        /// Region-specific prices for enabling Backups service.
        /// </summary>
        [JsonProperty("region_prices", NullValueHandling = NullValueHandling.Ignore)]
        public List<RegionPrice> RegionPrices { get; set; } = new List<RegionPrice>();
    }
}
