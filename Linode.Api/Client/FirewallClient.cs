using Linode.Api.Objets.Firewall.Get;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.Firewall;

namespace Linode.Api.Client
{
    public class FirewallClient
    {
        private readonly string _token;

        public FirewallClient(string token)
        {
            _token = token;
        }

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

        public async Task<Firewall> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networking/firewalls/{id}");

            // Set
            Firewall firewall = JsonConvert.DeserializeObject<Firewall>(json) ?? new Firewall();

            // Return
            return firewall;
        }
    }
}
