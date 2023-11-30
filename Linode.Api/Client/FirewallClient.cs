using Linode.Api.Objets.Firewall.Get;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Enums;
using Linode.Api.Objets.Firewall;
using Linode.Api.Objets.SshKey;

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

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/networking/firewalls", raw);

            // Return
            return JsonConvert.DeserializeObject<Firewall>(jsonResponse) ?? new Firewall();
        }

        /// <summary>
        /// Updates information for a Firewall.
        /// </summary>
        /// <param name="id">ID of the Firewall</param>
        /// <param name="firewallStatus"></param>
        /// <returns></returns>
        public async Task<Firewall> Update(long id, eFirewallStatus firewallStatus)
        {
            // Preparing raw
            string raw = $"{{ \"status\": \"{firewallStatus}\" }}";

            // Send post
            string jsonResponse = await Core.SendPutRequest(_token, $"/networking/firewalls/{id}", raw);

            // Return
            return JsonConvert.DeserializeObject<Firewall>(jsonResponse) ?? new Firewall();
        }

        /// <summary>
        /// Updates information for a Firewall.
        /// </summary>
        /// <param name="firewall">Firewall</param>
        /// <param name="firewallStatus"></param>
        /// <returns></returns>
        public async Task<Firewall> Update(Firewall firewall, eFirewallStatus firewallStatus)
        {
            return await Update(firewall.Id, firewallStatus);
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
    }
}
