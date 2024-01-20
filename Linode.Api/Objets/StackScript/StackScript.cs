using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Linode.Api.Objets.StackScript
{
    public class StackScript
    {
        /// <summary>
        /// The date this StackScript was created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// Count of currently active, deployed Linodes created from this StackScript.
        /// </summary>
        [JsonProperty("deployments_active", NullValueHandling = NullValueHandling.Ignore)]
        public long DeploymentsActive { get; set; } = 0;

        /// <summary>
        /// The total number of times this StackScript has been deployed.
        /// </summary>
        [JsonProperty("deployments_total", NullValueHandling = NullValueHandling.Ignore)]
        public long DeploymentsTotal { get; set; } = 0;

        /// <summary>
        /// A description for the StackScript.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The unique ID of this StackScript.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// An array of Image IDs. These are the Images that can be deployed with this StackScript.
        /// </summary>
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Images { get; set; } = new List<string>();

        /// <summary>
        /// This determines whether other users can use your StackScript. Once a StackScript is made public, it cannot be made private.
        /// </summary>
        [JsonProperty("is_public", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPublic { get; set; } = false;

        /// <summary>
        /// The StackScript’s label is for display purposes only.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Returns true if this StackScript is owned by the account of the user making the request, and the user making the request is unrestricted or has access to this StackScript.
        /// </summary>
        [JsonProperty("mine", NullValueHandling = NullValueHandling.Ignore)]
        public bool Mine { get; set; } = false;

        /// <summary>
        /// This field allows you to add notes for the set of revisions made to this StackScript.
        /// </summary>
        [JsonProperty("rev_note", NullValueHandling = NullValueHandling.Ignore)]
        public string RevNote { get; set; } = string.Empty;

        /// <summary>
        /// The script to execute when provisioning a new Linode with this StackScript.
        /// </summary>
        [JsonProperty("script", NullValueHandling = NullValueHandling.Ignore)]
        public string Script { get; set; } = string.Empty;

        /// <summary>
        /// The date this StackScript was last updated.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Updated { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// This is a list of fields defined with a special syntax inside this StackScript that allow for supplying customized parameters during deployment.
        /// </summary>
        [JsonProperty("user_defined_fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<UserDefinedField> UserDefinedFields { get; set; } = new List<UserDefinedField>();

        /// <summary>
        /// The Gravatar ID for the User who created the StackScript.
        /// </summary>
        [JsonProperty("user_gravatar_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserGravatarId { get; set; } = string.Empty;

        /// <summary>
        /// The User who created the StackScript.
        /// </summary>
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; } = string.Empty;
    }

    public class UserDefinedField
    {
        /// <summary>
        /// The default value. If not specified, this value will be used.
        /// </summary>
        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public string Default { get; set; } = string.Empty;

        /// <summary>
        /// An example value for the field.
        /// </summary>
        [JsonProperty("example", NullValueHandling = NullValueHandling.Ignore)]
        public string Example { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable label for the field that will serve as the input prompt for entering the value during deployment.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// A list of acceptable values for the field in any quantity, combination, or order.
        /// </summary>
        [JsonProperty("manyOf", NullValueHandling = NullValueHandling.Ignore)]
        public string ManyOf { get; set; } = string.Empty;

        /// <summary>
        /// The name of the field.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A list of acceptable single values for the field.
        /// </summary>
        [JsonProperty("oneOf", NullValueHandling = NullValueHandling.Ignore)]
        public string OneOf { get; set; } = string.Empty;
    }
}
