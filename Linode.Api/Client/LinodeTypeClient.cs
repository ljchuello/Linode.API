using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.LinodeType;
using Linode.Api.Objets.LinodeType.Get;

namespace Linode.Api.Client
{
    public class LinodeTypeClient
    {
        private readonly string _token;

        public LinodeTypeClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns collection of Linode Types, including pricing and specifications for each Type. These are used when creating or resizing Linodes.
        /// </summary>
        /// <returns></returns>
        public async Task<List<LinodeType>> Get()
        {
            List<LinodeType> list = new List<LinodeType>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/linode/types?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (LinodeType row in response.Data)
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
        /// Returns information about a specific Linode Type, including pricing and specifications. This is used when creating or resizing Linodes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LinodeType> Get(string id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/linode/types/{id}");

            // Set
            LinodeType linodeType = JsonConvert.DeserializeObject<LinodeType>(json) ?? new LinodeType();

            // Return
            return linodeType;
        }
    }
}
