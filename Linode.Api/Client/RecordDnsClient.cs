using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.RecordDns;
using Linode.Api.Objets.RecordDns.Get;
using Linode.Api.Objets.Domain;

namespace Linode.Api.Client
{
    public class RecordDnsClient
    {
        private readonly string _token;

        public RecordDnsClient(string token)
        {
            _token = token;
        }

        public async Task<List<RecordDns>> Get(long domainId)
        {
            List<RecordDns> list = new List<RecordDns>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/domains/{domainId}/records?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (RecordDns row in response.Data)
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

        public async Task<RecordDns> Get(long domainId, long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/domains/{domainId}/records/{id}");

            // Set
            RecordDns recordDns = JsonConvert.DeserializeObject<RecordDns>(json) ?? new RecordDns();

            // Return
            return recordDns;
        }

        public async Task<RecordDns> CreateIPv4(long domainId, string name, string target, long ttl)
        {
            // Preparing raw
            string raw = $"{{ \"type\": \"A\", \"name\": \"{name}\", \"target\": \"{target}\",\"ttl_sec\": {ttl}}}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/domains/{domainId}/records", raw);

            // Return
            return JsonConvert.DeserializeObject<RecordDns>(jsonResponse) ?? new RecordDns();
        }
    }
}
