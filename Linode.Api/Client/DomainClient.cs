using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.Domain;
using Linode.Api.Objets.Domain.Get;

namespace Linode.Api.Client
{
    public class DomainClient
    {
        private readonly string _token;

        public DomainClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// This is a collection of Domains that you have registered in Linode’s DNS Manager.   
        /// </summary>
        /// <returns></returns>
        public async Task<List<Domain>> Get()
        {
            List<Domain> list = new List<Domain>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/domains?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Domain row in response.Data)
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
        /// This is a single Domain that you have registered in Linode’s DNS Manager.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Domain> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/domains/{id}");

            // Set
            Domain domain = JsonConvert.DeserializeObject<Domain>(json) ?? new Domain();

            // Return
            return domain;
        }

        /// <summary>
        /// Adds a new Domain to Linode’s DNS Manager.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<Domain> Create(Domain domain)
        {
            // Preparing raw
            string raw = JsonConvert.SerializeObject(domain, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, "/domains", raw);

            // Return
            return JsonConvert.DeserializeObject<Domain>(jsonResponse) ?? new Domain();
        }

        /// <summary>
        /// Update information about a Domain in Linode’s DNS Manager.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<Domain> Update(Domain domain)
        {
            // Preparing raw
            string raw = JsonConvert.SerializeObject(domain, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/domains/{domain.Id}", raw);

            // Return
            return JsonConvert.DeserializeObject<Domain>(jsonResponse) ?? new Domain();
        }

        /// <summary>
        /// Deletes a Domain from Linode’s DNS Manager.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/domains/{id}");
        }

        /// <summary>
        /// Deletes a Domain from Linode’s DNS Manager.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task Delete(Domain domain)
        {
            await Delete(domain.Id);
        }
    }
}
