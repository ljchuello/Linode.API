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

        /// <summary>
        /// Returns a paginated list of Volumes you have permission to view.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get information about a single Volume.
        /// </summary>
        /// <param name="id">ID of the Volume to look up.</param>
        /// <returns></returns>
        public async Task<Volume> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/volumes/{id}");

            // Set
            Volume volume = JsonConvert.DeserializeObject<Volume>(json) ?? new Volume();

            // Return
            return volume;
        }

        /// <summary>
        /// Creates a Volume on your Account. In order for this to complete successfully, your User must have the add_volumes grant.
        /// </summary>
        /// <param name="label">The Volume’s label, which is also used in the filesystem_path of the resulting volume.</param>
        /// <param name="size">The initial size of this volume, in GB. Be aware that volumes may only be resized up after creation.</param>
        /// <param name="linodeId">The Linode this volume should be attached to upon creation. If not given, the volume will be created without an attachment.</param>
        /// <returns></returns>
        public async Task<Volume> Create(string label, long size, long linodeId)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{label}\", \"size\": {size}, \"linode_id\": {linodeId} }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, "/volumes", raw);

            // Return
            return JsonConvert.DeserializeObject<Volume>(jsonResponse) ?? new Volume();
        }

        /// <summary>
        /// Updates a Volume that you have permission to read_write.
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Attaches a Volume on your Account to an existing Linode on your Account.
        /// </summary>
        /// <param name="volumeId">ID of the Volume to attach.</param>
        /// <param name="linodeId">The ID of the Linode to attach the volume to.</param>
        /// <returns></returns>
        public async Task<Volume> Attach(long volumeId, long linodeId)
        {
            // Preparing raw
            string raw = $"{{ \"linode_id\": {linodeId} }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/attach", raw);

            // Return
            return JsonConvert.DeserializeObject<Volume>(jsonResponse) ?? new Volume();
        }

        /// <summary>
        /// Detaches a Volume on your Account from a Linode on your Account. 
        /// </summary>
        /// <param name="volumeId">ID of the Volume to detach.</param>
        /// <returns></returns>
        public async Task Detach(long volumeId)
        {
            // Send
            await Core.SendPostRequest(_token, $"/volumes/{volumeId}/detach");
        }

        /// <summary>
        /// Resize an existing Volume on your Account. 
        /// </summary>
        /// <param name="volumeId">ID of the Volume to resize.</param>
        /// <param name="size">The Volume’s size, in GiB.</param>
        /// <returns></returns>
        public async Task<Volume> Resize(long volumeId, long size)
        {
            // Preparing raw
            string raw = $"{{ \"size\": {size} }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/resize", raw);

            // Return
            return JsonConvert.DeserializeObject<Volume>(jsonResponse) ?? new Volume();
        }

        /// <summary>
        /// Create a copy of a Volume in your account
        /// </summary>
        /// <param name="volumeId">ID of the Volume to clone.</param>
        /// <param name="label">The Volume’s label is for display purposes only.</param>
        /// <returns></returns>
        public async Task<Volume> Clone(long volumeId, string label)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{label}\" }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/clone", raw);

            // Return
            return JsonConvert.DeserializeObject<Volume>(jsonResponse) ?? new Volume();
        }
    }
}
