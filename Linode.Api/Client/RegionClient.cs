using Newtonsoft.Json;
using System.Threading.Tasks;
using Linode.Api.Objets.Region;
using Linode.Api.Objets.Region.Get;
using System.Collections.Generic;

namespace Linode.Api.Client
{
    public class RegionClient
    {
        private readonly string _token;

        public RegionClient(string token)
        {
            _token = token;
        }

        public async Task<List<Region>> Get()
        {
            List<Region> list = new List<Region>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/regions?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Region row in response.Data)
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

        public async Task<Region> Get(string id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/regions/{id}");

            // Set
            Region region = JsonConvert.DeserializeObject<Region>(json) ?? new Region();

            // Return
            return region;
        }
    }
}
