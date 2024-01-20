using Newtonsoft.Json;
using System.Threading.Tasks;
using Linode.Api.Objets.StackScript;
using System.Collections.Generic;
using Linode.Api.Objets.StackScript.Get;

namespace Linode.Api.Client
{
    public class StackScriptClient
    {
        private readonly string _token;

        public StackScriptClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Get all StackScripts
        /// </summary>
        /// <returns></returns>
        public async Task<List<StackScript>> Get()
        {
            List<StackScript> list = new List<StackScript>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/linode/stackscripts?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (StackScript row in response.Data)
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
        /// Returns all of the information about a specified StackScript, including the contents of the script.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StackScript> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/linode/stackscripts/{id}");

            // Set
            StackScript stackScript = JsonConvert.DeserializeObject<StackScript>(json) ?? new StackScript();

            // Return
            return stackScript;
        }

        /// <summary>
        /// Creates a StackScript in your Account.
        /// </summary>
        /// <param name="label">The StackScript’s label is for display purposes only</param>
        /// <param name="images">An array of Image IDs. These are the Images that can be deployed with this StackScript</param>
        /// <param name="script">The script to execute when provisioning a new Linode with this StackScript</param>
        /// <param name="description">A description for the StackScript</param>
        /// <param name="revNote">This field allows you to add notes for the set of revisions made to this StackScript</param>
        /// <param name="isPublic">This determines whether other users can use your StackScript. Once a StackScript is made public, it cannot be made private</param>
        /// <returns></returns>
        public async Task<StackScript> Create(string label, List<string> images, string script, string description = "", string revNote = "", bool isPublic = false)
        {
            // Set
            StackScript stackScript = new StackScript();
            stackScript.Label = label;
            stackScript.Images = images;
            stackScript.Script = script;
            stackScript.Description = description;
            stackScript.RevNote = revNote;
            stackScript.IsPublic = isPublic;

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, "/linode/stackscripts", JsonConvert.SerializeObject(stackScript, Formatting.Indented));

            // Return
            return JsonConvert.DeserializeObject<StackScript>(jsonResponse) ?? new StackScript();
        }

        /// <summary>
        /// Updates a StackScript
        /// </summary>
        /// <param name="stackScript"></param>
        /// <returns></returns>
        public async Task<StackScript> Update(StackScript stackScript)
        {
            // Preparing raw
            string raw = JsonConvert.SerializeObject(stackScript, Formatting.Indented);

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/linode/stackscripts/{stackScript.Id}", raw);

            // Return
            return JsonConvert.DeserializeObject<StackScript>(jsonResponse) ?? new StackScript();
        }

        /// <summary>
        /// Deletes a private StackScript
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/linode/stackscripts/{id}");
        }

        /// <summary>
        /// Deletes a private StackScript
        /// </summary>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        public async Task Delete(StackScript sshKey)
        {
            await Delete(sshKey.Id);
        }
    }
}
