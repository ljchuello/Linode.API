using Linode.Api.Objets.Firewall.Get;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.Firewall;
using Linode.Api.Objets.FirewallDevice;

namespace Linode.Api.Client
{
    public class FirewallClient
    {
        private readonly string _token;

        public FirewallClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns a paginated list of accessible Firewalls.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Firewall>> Get()
        {
            List<Firewall> list = new List<Firewall>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/networking/firewalls?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Firewall row in response.Data)
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
        /// Get a specific Firewall resource by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Firewall> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networking/firewalls/{id}");

            // Set
            Firewall firewall = JsonConvert.DeserializeObject<Firewall>(json) ?? new Firewall();

            // Return
            return firewall;
        }

        /// <summary>
        /// Creates a Firewall to filter network traffic.
        /// </summary>
        /// <param name="firewall"></param>
        /// <returns></returns>
        public async Task<Firewall> Create(Firewall firewall)
        {
            // Preparing raw
            string raw = JsonConvert.SerializeObject(firewall, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, "/networking/firewalls", raw);

            // Return
            return JsonConvert.DeserializeObject<Firewall>(jsonResponse) ?? new Firewall();
        }

        /// <summary>
        /// Updates information for a Firewall.
        /// </summary>
        /// <param name="firewall">Firewall</param>
        /// <returns></returns>
        public async Task<Firewall> Update(Firewall firewall)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{firewall.Label}\", \"status\": \"{firewall.Status}\" }}";

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/networking/firewalls/{firewall.Id}", raw);

            // Return
            return JsonConvert.DeserializeObject<Firewall>(jsonResponse) ?? new Firewall();
        }

        /// <summary>
        /// Delete a Firewall resource
        /// </summary>
        /// <param name="id">ID of the Firewall</param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/networking/firewalls/{id}");
        }

        /// <summary>
        /// Delete a Firewall resource
        /// </summary>
        /// <param name="firewall">Firewall</param>
        /// <returns></returns>
        public async Task Delete(Firewall firewall)
        {
            await Delete(firewall.Id);
        }

        /// <summary>
        /// Returns the inbound and outbound Rules for a Firewall.
        /// </summary>
        /// <param name="id">ID of the Firewall</param>
        /// <returns></returns>
        public async Task<FirewallRules> GetRules(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networking/firewalls/{id}/rules");

            // Set
            FirewallRules firewallRule = JsonConvert.DeserializeObject<FirewallRules>(json) ?? new FirewallRules();

            // Return
            return firewallRule;
        }

        /// <summary>
        /// Updates the inbound and outbound Rules for a Firewall.
        /// </summary>
        /// <param name="firewallId">ID of the Firewall</param>
        /// <param name="firewallRules">Rules</param>
        /// <returns></returns>
        public async Task<FirewallRules> UpdateRule(long firewallId, FirewallRules firewallRules)
        {
            // Preparing raw
            string raw = JsonConvert.SerializeObject(firewallRules, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/networking/firewalls/{firewallId}/rules", raw);

            // Return
            return JsonConvert.DeserializeObject<FirewallRules>(jsonResponse) ?? new FirewallRules();
        }

        /// <summary>
        /// Returns a paginated list of a Firewall’s Devices.
        /// </summary>
        /// <param name="firewallId"></param>
        /// <returns></returns>
        public async Task<List<FirewallDevice>> DeviceGet(long firewallId)
        {
            List<FirewallDevice> list = new List<FirewallDevice>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Objets.FirewallDevice.Get.Response response = JsonConvert.DeserializeObject<Objets.FirewallDevice.Get.Response>(await Core.SendGetRequest(_token, $"/networking/firewalls/{firewallId}/devices?page={page}&page_size={Core.PerPage}")) ?? new Objets.FirewallDevice.Get.Response();

                // Run
                foreach (FirewallDevice row in response.Data)
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
        /// ID of the Firewall Device to access
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<FirewallDevice> DeviceGet(long firewallId, long deviceId)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networking/firewalls/{firewallId}/devices/{deviceId}");

            // Set
            FirewallDevice firewallDevice = JsonConvert.DeserializeObject<FirewallDevice>(json) ?? new FirewallDevice();

            // Return
            return firewallDevice;
        }

        /// <summary>
        /// Device Create
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="linodeId"></param>
        /// <returns></returns>
        public async Task<FirewallDevice> DeviceCreate(long firewallId, long linodeId)
        {
            // Preparing raw
            string raw = $"{{ \"type\": \"linode\", \"id\": {linodeId} }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/networking/firewalls/{firewallId}/devices", raw);

            // Return
            return JsonConvert.DeserializeObject<FirewallDevice>(jsonResponse) ?? new FirewallDevice();
        }

        /// <summary>
        /// Device Delete
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task DeviceDelete(long firewallId, long deviceId)
        {
            await Core.SendDeleteRequest(_token, $"/networking/firewalls/{firewallId}/devices/{deviceId}");
        }
    }
}
