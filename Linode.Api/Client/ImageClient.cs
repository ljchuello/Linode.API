using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Linode.Api.Objets.Image;
using Linode.Api.Objets.Image.Get;

namespace Linode.Api.Client
{
    public class ImageClient
    {
        private readonly string _token;

        public ImageClient(string token)
        {
            _token = token;
        }

        public async Task<List<Image>> Get()
        {
            List<Image> list = new List<Image>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/images/?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Image row in response.Data)
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

        public async Task<Image> Get(string id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/images/{id}");

            // Set
            Image image = JsonConvert.DeserializeObject<Image>(json) ?? new Image();

            // Return
            return image;
        }
    }
}
