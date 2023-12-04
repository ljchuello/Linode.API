using Newtonsoft.Json;
using System.Collections.Generic;
using Linode.Api.Enums;

namespace Linode.Api.Objets.Domain
{
    public class Domain
    {
        /// <summary>
        /// This Domain’s unique ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// The type of the domain (e.g., "master" or "slave").
        /// </summary>
        [JsonProperty("type")]
        public DomainType Type { get; set; } = DomainType.master;

        /// <summary>
        /// The domain this Domain represents.
        /// </summary>
        [JsonProperty("domain")]
        public string Domains { get; set; } = string.Empty;

        /// <summary>
        /// The list of IPs that may perform a zone transfer for this Domain.
        /// </summary>
        [JsonProperty("axfr_ips")]
        public List<string> AxfrIps { get; set; } = new List<string>();

        /// <summary>
        /// A description for this Domain. This is for display purposes only.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The group this Domain belongs to. This is for display purposes only.
        /// </summary>
        [JsonProperty("group")]
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// The IP addresses representing the master DNS for this Domain.
        /// </summary>
        [JsonProperty("master_ips")]
        public List<string> MasterIps { get; set; } = new List<string>();

        /// <summary>
        /// The amount of time in seconds that may pass before this Domain is no longer authoritative.
        /// </summary>
        [JsonProperty("expire_sec")]
        public long ExpireSec { get; set; } = 0;

        /// <summary>
        /// The amount of time in seconds before this Domain should be refreshed.
        /// </summary>
        [JsonProperty("refresh_sec")]
        public long RefreshSec { get; set; } = 0;

        /// <summary>
        /// The interval, in seconds, at which a failed refresh should be retried.
        /// </summary>
        [JsonProperty("retry_sec")]
        public long RetrySec { get; set; } = 0;

        /// <summary>
        /// Start of Authority email address. This is required for type master Domains.
        /// </summary>
        [JsonProperty("soa_email")]
        public string SoaEmail { get; set; } = string.Empty;

        /// <summary>
        /// Used to control whether this Domain is currently being rendered.
        /// </summary>
        [JsonProperty("status")]
        public DomainStatus Status { get; set; } = DomainStatus.active;

        /// <summary>
        /// An array of tags applied to this object. Tags are for organizational purposes only.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// “Time to Live” - the amount of time in seconds that this Domain’s records may be cached by resolvers or other domain servers.
        /// </summary>
        [JsonProperty("ttl_sec")]
        public long TtlSec { get; set; } = 0;
    }
}