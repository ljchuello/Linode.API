using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.LinodeInstance;
using Linode.Api.Objets.LinodeInstance.Get;
using System.Linq;
using Linode.Api.Objets.Domain;

namespace Linode.Api.Client
{
    public class LinodeInstanceClient
    {
        private readonly string _token;

        public LinodeInstanceClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns a paginated list of Linodes you have permission to view.
        /// </summary>
        /// <returns></returns>
        public async Task<List<LinodeInstance>> Get()
        {
            List<LinodeInstance> list = new List<LinodeInstance>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/linode/instances?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (LinodeInstance row in response.Data)
                {
                    list.Add(row);
                }

                // Finish?
                if (response.Page >= response.Pages)
                {
                    // Yes, finish
                    return list;
                }
            }
        }

        /// <summary>
        /// Get a specific Linode by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LinodeInstance> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/linode/instances/{id}");

            // Set
            LinodeInstance linodeInstance = JsonConvert.DeserializeObject<LinodeInstance>(json) ?? new LinodeInstance();

            // Return
            return linodeInstance;
        }

        /// <summary>
        /// Creates a Linode Instance on your Account
        /// </summary>
        /// <param name="label">The Linode’s label is for display purposes only. If no label is provided for a Linode, a default will be assigned.</param>
        /// <param name="regionId">The Region where the Linode will be located.</param>
        /// <param name="linodeType">The Linode Type of the Linode you are creating.</param>
        /// <param name="imageId">An Image ID to deploy the Linode Disk from.</param>
        /// <param name="rootPassword">This sets the root user’s password on a newly-created Linode Disk when deploying from an Image.</param>
        /// <param name="authorizedUsers">A list of usernames. If the usernames have associated SSH keys, the keys will be appended to the root users ~/.ssh/authorized_keys file automatically when deploying from an Image.</param>
        /// <param name="authorizedKeys">A list of public SSH keys that will be automatically appended to the root user’s ~/.ssh/authorized_keys file when deploying from an Image.</param>
        /// <param name="backups">If this field is set to true, the created Linode will automatically be enrolled in the Linode Backup service. This will incur an additional charge. The cost for the Backup service is dependent on the Type of Linode deployed.</param>
        /// <param name="firewallId">The id of the Firewall to attach this Linode to upon creation.</param>
        /// <param name="stackscriptId">A StackScript ID that will cause the referenced StackScript to be run during deployment of this Linode.</param>
        /// <param name="privateIp">If true, the created Linode will have private networking enabled and assigned a private IPv4 address.</param>
        /// <param name="tags">An array of tags applied to this object. Tags are for organizational purposes only.</param>
        /// <returns></returns>
        public async Task<LinodeInstance> Create(string label, string regionId, string linodeType, string imageId, string rootPassword, List<string> authorizedUsers = null, List<string> authorizedKeys = null, bool backups = false, long firewallId = 0, long stackscriptId = 0, bool privateIp = false, List<string> tags = null)
        {
            // Preparing raw
            CreateLinodeInstance createLinodeInstance = new CreateLinodeInstance();
            createLinodeInstance.Label = label;
            createLinodeInstance.Region = regionId;
            createLinodeInstance.Type = linodeType;
            createLinodeInstance.Image = imageId;
            createLinodeInstance.RootPass = rootPassword;
            createLinodeInstance.AuthorizedUsers = authorizedUsers;
            createLinodeInstance.AuthorizedKeys = authorizedKeys;
            createLinodeInstance.BackupsEnabled = backups;
            createLinodeInstance.FirewallId = firewallId;
            if (stackscriptId > 0)
            {
                createLinodeInstance.StackscriptId = stackscriptId;
            }
            else
            {
                createLinodeInstance.StackscriptId = null;
            }
            createLinodeInstance.Booted = true;
            createLinodeInstance.PrivateIp = privateIp;
            createLinodeInstance.Tags = tags;

            // json
            string json = JsonConvert.SerializeObject(createLinodeInstance, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, "/linode/instances", json);

            // Return
            return JsonConvert.DeserializeObject<LinodeInstance>(jsonResponse) ?? new LinodeInstance();
        }

        /// <summary>
        /// Updates a Linode
        /// </summary>
        /// <param name="linodeInstance"></param>
        /// <returns></returns>
        public async Task<LinodeInstance> Update(LinodeInstance linodeInstance)
        {
            // json
            string json = $"{{ \"label\": \"{linodeInstance.Label}\", \"tags\": [ {string.Join(", ", linodeInstance.Tags.Select(tag => $"\"{tag}\""))} ] }}";

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/linode/instances/{linodeInstance.Id}", json);

            // Return
            return JsonConvert.DeserializeObject<LinodeInstance>(jsonResponse) ?? new LinodeInstance();
        }

        /// <summary>
        /// Deletes a Linode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/linode/instances/{id}");
        }

        /// <summary>
        /// Deletes a Linode
        /// </summary>
        /// <param name="linodeInstance"></param>
        /// <returns></returns>
        public async Task Delete(LinodeInstance linodeInstance)
        {
            await Delete(linodeInstance.Id);
        }

        #region Object Create

        private class CreateLinodeInstance
        {
            [JsonProperty("authorized_users", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> AuthorizedUsers { get; set; } = new List<string>();

            [JsonProperty("backups_enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool BackupsEnabled { get; set; } = false;

            [JsonProperty("booted", NullValueHandling = NullValueHandling.Ignore)]
            public bool Booted { get; set; } = false;

            [JsonProperty("firewall_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? FirewallId { get; set; } = 0;

            [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
            public string Image { get; set; } = string.Empty;

            [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
            public string Label { get; set; } = string.Empty;

            [JsonProperty("private_ip", NullValueHandling = NullValueHandling.Ignore)]
            public bool PrivateIp { get; set; } = false;

            [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
            public string Region { get; set; } = string.Empty;

            [JsonProperty("root_pass", NullValueHandling = NullValueHandling.Ignore)]
            public string RootPass { get; set; } = string.Empty;

            [JsonProperty("authorized_keys", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> AuthorizedKeys { get; set; } = new List<string>();

            [JsonProperty("stackscript_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackscriptId { get; set; } = 0;

            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Tags { get; set; } = new List<string>();

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; } = string.Empty;
        }

        #endregion
    }
}
