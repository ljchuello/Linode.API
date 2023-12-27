using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Linode.Api.Objets.LinodeInstance
{
    public class LinodeInstance
    {
        /// <summary>
        /// This Linode’s ID which must be provided for all operations impacting this Linode.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// The Linode’s label is for display purposes only. If no label is provided for a Linode, a default will be assigned.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// A deprecated property denoting a group label for this Linode.
        /// </summary>
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// When this Linode was created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// When this Linode was last updated.
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Updated { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// Enum: running offline booting rebooting shutting_down provisioning deleting migrating rebuilding cloning restoring stopped billing_suspension
        /// A brief description of this Linode’s current state.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// This is the Region where the Linode was deployed. A Linode’s region can only be changed by initiating a cross data center migration.
        /// </summary>
        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; } = string.Empty;

        /// <summary>
        /// This is the Linode Type that this Linode was deployed with. To change a Linode’s Type, use POST /linode/instances/{linodeId}/resize.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// An Image ID to deploy the Linode Disk from.
        /// </summary>
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Information about the resources available to this Linode.
        /// </summary>
        [JsonProperty("specs", NullValueHandling = NullValueHandling.Ignore)]
        public LinodeSpecs Specs { get; set; } = new LinodeSpecs();

        /// <summary>
        /// This Linode’s IPv4 Addresses. Each Linode is assigned a single public IPv4 address upon creation, and may get a single private IPv4 address if needed.
        /// </summary>
        [JsonProperty("ipv4", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IPv4 { get; set; } = new List<string>();

        /// <summary>
        /// This Linode’s IPv6 SLAAC address. This address is specific to a Linode, and may not be shared. 
        /// </summary>
        [JsonProperty("ipv6", NullValueHandling = NullValueHandling.Ignore)]
        public string IPv6 { get; set; } = string.Empty;

        /// <summary>
        /// The watchdog, named Lassie, is a Shutdown Watchdog that monitors your Linode and will reboot it if it powers off unexpectedly
        /// </summary>
        [JsonProperty("watchdog_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool WatchdogEnabled { get; set; } = false;

        /// <summary>
        /// Whether this compute instance was provisioned utilizing user_data provided via the Metadata service
        /// </summary>
        [JsonProperty("has_user_data", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasUserData { get; set; } = false;

        /// <summary>
        /// The Linode’s host machine, as a UUID.
        /// </summary>
        [JsonProperty("host_uuid", NullValueHandling = NullValueHandling.Ignore)]
        public string HostUUID { get; set; } = string.Empty;

        /// <summary>
        /// The virtualization software powering this Linode.
        /// </summary>
        [JsonProperty("hypervisor", NullValueHandling = NullValueHandling.Ignore)]
        public string Hypervisor { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("alerts", NullValueHandling = NullValueHandling.Ignore)]
        public LinodeAlerts Alerts { get; set; } = new LinodeAlerts();

        /// <summary>
        /// Information about this Linode’s backups status. 
        /// </summary>
        [JsonProperty("backups", NullValueHandling = NullValueHandling.Ignore)]
        public LinodeBackups Backups { get; set; } = new LinodeBackups();

        /// <summary>
        /// An array of tags applied to this object. Tags are for organizational purposes only.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; } = new List<string>();
    }

    public class LinodeSpecs
    {
        /// <summary>
        /// The amount of storage space, in MB, this Linode has access to. A typical Linode will divide this space between a primary disk with an image deployed to it, and a swap disk, usually 512 MB.
        /// </summary>
        [JsonProperty("disk", NullValueHandling = NullValueHandling.Ignore)]
        public long Disk { get; set; } = 0;

        /// <summary>
        /// The number of gpus this Linode has access to.
        /// </summary>
        [JsonProperty("gpus", NullValueHandling = NullValueHandling.Ignore)]
        public long GPUs { get; set; } = 0;

        /// <summary>
        /// The amount of RAM, in MB, this Linode has access to.
        /// </summary>
        [JsonProperty("memory", NullValueHandling = NullValueHandling.Ignore)]
        public long Memory { get; set; } = 0;

        /// <summary>
        /// The amount of network transfer this Linode is allotted each month.
        /// </summary>
        [JsonProperty("transfer", NullValueHandling = NullValueHandling.Ignore)]
        public long Transfer { get; set; } = 0;

        /// <summary>
        /// The number of vcpus this Linode has access to.
        /// </summary>
        [JsonProperty("vcpus", NullValueHandling = NullValueHandling.Ignore)]
        public long VCPUs { get; set; } = 0;
    }

    public class LinodeAlerts
    {
        /// <summary>
        /// The percentage of CPU usage required to trigger an alert
        /// </summary>
        [JsonProperty("cpu", NullValueHandling = NullValueHandling.Ignore)]
        public long CPU { get; set; } = 0;

        /// <summary>
        /// The amount of disk IO operation per second required to trigger an alert
        /// </summary>
        [JsonProperty("io", NullValueHandling = NullValueHandling.Ignore)]
        public long IO { get; set; } = 0;

        /// <summary>
        /// The amount of incoming traffic, in Mbit/s, required to trigger an alert
        /// </summary>
        [JsonProperty("network_in", NullValueHandling = NullValueHandling.Ignore)]
        public long NetworkIn { get; set; } = 0;

        /// <summary>
        /// The amount of outbound traffic, in Mbit/s, required to trigger an alert
        /// </summary>
        [JsonProperty("network_out", NullValueHandling = NullValueHandling.Ignore)]
        public long NetworkOut { get; set; } = 0;

        /// <summary>
        /// The percentage of network transfer that may be used before an alert is triggered
        /// </summary>
        [JsonProperty("transfer_quota", NullValueHandling = NullValueHandling.Ignore)]
        public long TransferQuota { get; set; } = 0;
    }

    public class LinodeBackups
    {
        /// <summary>
        /// Whether Backups for this Linode are available for restoration
        /// </summary>
        [JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        public bool Available { get; set; } = false;

        /// <summary>
        /// If this Linode has the Backup service enabled
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// The last successful backup date. ’null’ if there was no previous backup
        /// </summary>
        [JsonProperty("last_successful", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastSuccessful { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)]
        public LinodeBackupSchedule Schedule { get; set; } = new LinodeBackupSchedule();
    }

    public class LinodeBackupSchedule
    {
        /// <summary>
        /// The day of the week that your Linode’s weekly Backup is taken
        /// </summary>
        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        public string Day { get; set; } = string.Empty;

        /// <summary>
        /// The window in which your backups will be taken, in UTC
        /// </summary>
        [JsonProperty("window", NullValueHandling = NullValueHandling.Ignore)]
        public string Window { get; set; } = string.Empty;
    }
}
