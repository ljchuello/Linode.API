using Linode.Api.Client;

namespace Linode.Api
{
    public class LinodeClient
    {
        public string Token { get; private set; }

        public LinodeClient(string token)
        {
            Token = token;

            Region = new RegionClient(token);
        }

        public RegionClient Region { get; private set; }
    }
}
