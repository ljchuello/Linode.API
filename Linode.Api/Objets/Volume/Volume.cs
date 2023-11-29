using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Linode.Api.Objets.Volume
{
    public class Volume
    {
        /// <summary>
        /// The unique ID of this Volume.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// The current status of the volume. Can be one of:
        /// - creating: the Volume is being created and is not yet available for use.
        /// - active: the Volume is online and available for use.
        /// - resizing: the Volume is in the process of upgrading its current capacity.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// The Volume’s label is for display purposes only.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// When this Volume was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// When this Volume was last updated.
        /// </summary>
        [JsonProperty("updated")]
        public DateTime Updated { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// The full filesystem path for the Volume based on the Volume’s label.
        /// Path is /dev/disk/by-id/scsi-0Linode_Volume_ + Volume label.
        /// </summary>
        [JsonProperty("filesystem_path")]
        public string FilesystemPath { get; set; } = string.Empty;

        /// <summary>
        /// The Volume’s size, in GiB.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; } = 0;

        /// <summary>
        /// If a Volume is attached to a specific Linode, the ID of that Linode will be displayed here.
        /// </summary>
        [JsonProperty("linode_id")]
        public long? LinodeId { get; set; } = null;

        /// <summary>
        /// If a Volume is attached to a specific Linode, the label of that Linode will be displayed here.
        /// </summary>
        [JsonProperty("linode_label")]
        public string LinodeLabel { get; set; } = string.Empty;

        /// <summary>
        /// The unique ID of this Region.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; } = string.Empty;

        /// <summary>
        /// An array of Tags applied to this object. Tags are for organizational purposes only.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// The storage type of this Volume. Enum: hdd nvme.
        /// </summary>
        [JsonProperty("hardware_type")]
        public string HardwareType { get; set; } = string.Empty;
    }
}
