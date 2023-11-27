using Linode.Api.Client;

namespace Linode.Api
{
    public class LinodeClient
    {
        public string Token { get; private set; }

        public LinodeClient(string token)
        {
            Token = token;

            LinodeType = new LinodeTypeClient(token);
            Region = new RegionClient(token);
        }

        public LinodeTypeClient LinodeType { get; private set; }
        public RegionClient Region { get; private set; }
    }
}
