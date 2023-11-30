using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Linode.Api.Objets.Firewall
{
    public class Firewall
    {
        /// <summary>
        /// The Firewall’s unique ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// When this Firewall was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// The Firewall’s label, for display purposes only.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// The inbound and outbound access rules to apply to the Firewall.
        /// </summary>
        [JsonProperty("rules")]
        public FirewallRules Rules { get; set; } = new FirewallRules();

        /// <summary>
        /// The status of this Firewall.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// An array of tags applied to this object. Tags are for organizational purposes only.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// When this Firewall was last updated.
        /// </summary>
        [JsonProperty("updated")]
        public DateTime Updated { get; set; } = new DateTime(1900, 1, 1);
    }

    public class FirewallRules
    {
        /// <summary>
        /// The inbound rules for the firewall, as a JSON array.
        /// </summary>
        [JsonProperty("inbound")]
        public List<FirewallRule> Inbound { get; set; } = new List<FirewallRule>();

        /// <summary>
        /// The default behavior for inbound traffic. This setting can be overridden by updating the inbound.action property of the Firewall Rule.
        /// </summary>
        [JsonProperty("inbound_policy")]
        public string InboundPolicy { get; set; } = string.Empty;

        /// <summary>
        /// The outbound rules for the firewall, as a JSON array.
        /// </summary>
        [JsonProperty("outbound")]
        public List<FirewallRule> Outbound { get; set; } = new List<FirewallRule>();

        /// <summary>
        /// The default behavior for outbound traffic. This setting can be overridden by updating the outbound.action property of the Firewall Rule.
        /// </summary>
        [JsonProperty("outbound_policy")]
        public string OutboundPolicy { get; set; } = string.Empty;
    }

    public class FirewallRule
    {
        /// <summary>
        /// Controls whether traffic is accepted or dropped by this rule.
        /// Overrides the Firewall’s inbound_policy if this is an inbound rule, or the outbound_policy if this is an outbound rule.
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// The IPv4 and/or IPv6 addresses affected by this rule.
        /// A Rule can have up to 255 total addresses or networks listed across its IPv4 and IPv6 arrays.
        /// A network and a single IP are treated as equivalent when accounting for this limit.
        /// </summary>
        [JsonProperty("addresses")]
        public FirewallRuleAddresses Addresses { get; set; } = new FirewallRuleAddresses();

        /// <summary>
        /// Used to describe this rule. For display purposes only.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Used to identify this rule. For display purposes only.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// A string representing the port or ports affected by this rule.
        /// </summary>
        [JsonProperty("ports")]
        public string Ports { get; set; } = string.Empty;

        /// <summary>
        /// The type of network traffic affected by this rule.
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; } = string.Empty;
    }

    public class FirewallRuleAddresses
    {
        /// <summary>
        /// A list of IPv4 addresses or networks. Addresses must be in IP/mask format. Must not be an empty list.
        /// </summary>
        [JsonProperty("ipv4")]
        public List<string> IPv4 { get; set; } = new List<string>();

        /// <summary>
        /// A list of IPv6 addresses or networks. Addresses must be in IP/mask format. Must not be an empty list.
        /// </summary>
        [JsonProperty("ipv6")]
        public List<string> IPv6 { get; set; } = new List<string>();
    }
}
