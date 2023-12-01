using Newtonsoft.Json;
using System;

namespace Linode.Api.Objets.FirewallDevice
{
    public class FirewallDevice
    {
        /// <summary>
        /// When this Device was created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = DateTime.MinValue;

        /// <summary>
        /// The Linode service that this Firewall has been applied to.
        /// </summary>
        [JsonProperty("entity", NullValueHandling = NullValueHandling.Ignore)]
        public Entity Entity { get; set; } = new Entity();

        /// <summary>
        /// The Device’s unique ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; } = default;

        /// <summary>
        /// When this Device was last updated.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Updated { get; set; } = DateTime.MinValue;
    }

    public class Entity
    {
        /// <summary>
        /// The entity’s ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; } = default;

        /// <summary>
        /// The entity’s label.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// The entity’s type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The URL you can use to access this entity.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; } = string.Empty;
    }
}
