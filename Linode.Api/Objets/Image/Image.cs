using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Linode.Api.Objets.Image
{
    public class Image
    {
        /// <summary>
        /// The unique ID of this Image.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// A short description of the Image.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Whether or not this Image is deprecated. Will only be true for deprecated public Images.
        /// </summary>
        [JsonProperty("deprecated", NullValueHandling = NullValueHandling.Ignore)]
        public bool Deprecated { get; set; } = false;

        /// <summary>
        /// The minimum size this Image needs to deploy. Size is in MB.
        /// </summary>
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public int Size { get; set; } = 0;

        /// <summary>
        /// When this Image was created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// When this Image was last updated.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Updated { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// A detailed description of this Image.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The name of the User who created this Image, or “linode” for public Images.
        /// </summary>
        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// How the Image was created. “Manual” Images can be created at any time. “Automatic” Images are created automatically from a deleted Linode.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// True if the Image is a public distribution image. False if Image is private Account-specific Image.
        /// </summary>
        [JsonProperty("is_public", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPublic { get; set; } = false;

        /// <summary>
        /// The upstream distribution vendor. None for private Images.
        /// </summary>
        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string Vendor { get; set; } = string.Empty;

        /// <summary>
        /// The date of the public Image’s planned end of life. None for private Images.
        /// </summary>
        [JsonProperty("eol", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Eol { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// The current status of this Image. Only Images in an “available” status can be deployed.
        /// Images in a “creating” status are being created from a Linode Disk, and will become “available” shortly.
        /// Images in a “pending_upload” status are waiting for data to be uploaded, and become “available” after the upload and processing are complete.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Only Images created automatically from a deleted Linode (type=automatic) will expire.
        /// </summary>
        [JsonProperty("expiry", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Expiry { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// A list containing the following possible capabilities of this Image: cloud-init: This Image supports cloud-init with Metadata. Only applies to public Images.
        /// </summary>
        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Capabilities { get; set; } = new List<string>();
    }
}
