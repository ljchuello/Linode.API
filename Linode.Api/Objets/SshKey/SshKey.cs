using Newtonsoft.Json;
using System;

namespace Linode.Api.Objets.SshKey
{
    public class SshKey
    {
        /// <summary>
        /// The unique identifier of an SSH Key object.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// A label for the SSH Key.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// The public SSH Key, which is used to authenticate to the root user of the Linodes you deploy.
        /// </summary>
        [JsonProperty("ssh_key")]
        public string SshKeyString { get; set; } = string.Empty;

        /// <summary>
        /// The date this key was added.
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);
    }
}
