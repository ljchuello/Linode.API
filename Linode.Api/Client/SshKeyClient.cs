using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Linode.Api.Objets.SshKey;
using Linode.Api.Objets.SshKey.Get;

namespace Linode.Api.Client
{
    public class SshKeyClient
    {
        private readonly string _token;

        public SshKeyClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns a collection of SSH Keys you’ve added to your Profile.
        /// </summary>
        /// <returns></returns>
        public async Task<List<SshKey>> Get()
        {
            List<SshKey> list = new List<SshKey>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/profile/sshkeys?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (SshKey row in response.Data)
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
        /// Returns a single SSH Key object identified by id that you have access to view.
        /// </summary>
        /// <param name="id">The ID of the SSHKey</param>
        /// <returns></returns>
        public async Task<SshKey> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/profile/sshkeys/{id}");

            // Set
            SshKey sshKey = JsonConvert.DeserializeObject<SshKey>(json) ?? new SshKey();

            // Return
            return sshKey;
        }

        /// <summary>
        /// Adds an SSH Key to your Account profile.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        public async Task<SshKey> Create(string label, string sshKey)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{label}\", \"ssh_key\": \"{sshKey}\" }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/profile/sshkeys", raw);

            // Return
            return JsonConvert.DeserializeObject<SshKey>(jsonResponse) ?? new SshKey();
        }

        /// <summary>
        /// Updates an SSH Key that you have permission to read_write. Only SSH key labels can be updated.
        /// </summary>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        public async Task<SshKey> Update(SshKey sshKey)
        {
            // Preparing raw
            string raw = $"{{ \"label\": \"{sshKey.Label}\" }}";

            // Send post
            string jsonResponse = await Core.SendPutRequest(_token, $"/profile/sshkeys/{sshKey.Id}", raw);

            // Return
            return JsonConvert.DeserializeObject<SshKey>(jsonResponse) ?? new SshKey();
        }

        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/profile/sshkeys/{id}");
        }

        public async Task Delete(SshKey sshKey)
        {
            await Delete(sshKey.Id);
        }
    }
}
