using Linode.Api.Objets.Volume.Get;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.Volume;
using Linode.Api.Objets.SshKey;

namespace Linode.Api.Client
{
    public class VolumeClient
    {
        private readonly string _token;

        public VolumeClient(string token)
        {
            _token = token;
        }

        public async Task<List<Volume>> Get()
        {
            List<Volume> list = new List<Volume>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/volumes?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Volume row in response.Data)
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

        public async Task<Volume> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/volumes/{id}");

            // Set
            Volume volume = JsonConvert.DeserializeObject<Volume>(json) ?? new Volume();

            // Return
            return volume;
        }

        public async Task<Volume> Create(string label, long size, long linodeId)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{label}\", \"size\": {size}, \"linode_id\": {linodeId} }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/volumes", raw);

            // Return
            return JsonConvert.DeserializeObject<Volume>(jsonResponse) ?? new Volume();
        }

        public async Task<Volume> Update(Volume volume)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{volume.Label}\" }}";

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/volumes/{volume.Id}", raw);

            // Return
            return JsonConvert.DeserializeObject<Volume>(jsonResponse) ?? new Volume();
        }

        /// <summary>
        /// Deletes a Volume you have permission to read_write.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/volumes/{id}");
        }

        /// <summary>
        /// Deletes a Volume you have permission to read_write.
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public async Task Delete(Volume volume)
        {
            await Delete(volume.Id);
        }
    }
}
