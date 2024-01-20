using Newtonsoft.Json;
using System.Threading.Tasks;
using Linode.Api.Objets.StackScript;

namespace Linode.Api.Client
{
   public class StackScriptClient
    {
        private readonly string _token;

        public StackScriptClient(string token)
        {
            _token = token;
        }

        public async Task<StackScript> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/linode/stackscripts/{id}");

            // Set
            StackScript stackScript = JsonConvert.DeserializeObject<StackScript>(json) ?? new StackScript();

            // Return
            return stackScript;
        }
    }
}
