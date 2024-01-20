using Linode.Api.Client;

namespace Linode.Api
{
    public class LinodeClient
    {
        public string Token { get; private set; }

        public LinodeClient(string token)
        {
            Token = token;

            Domain = new DomainClient(token);
            RecordDns = new RecordDnsClient(token);
            Firewall = new FirewallClient(token);
            Image = new ImageClient(token);
            LinodeInstance = new LinodeInstanceClient(token);
            LinodeType = new LinodeTypeClient(token);
            Region = new RegionClient(token);
            SshKey = new SshKeyClient(token);
            StackScript = new StackScriptClient(token);
            Volume = new VolumeClient(token);
        }

        public DomainClient Domain { get; private set; }
        public RecordDnsClient RecordDns { get; private set; }
        public FirewallClient Firewall { get; private set; }
        public ImageClient Image { get; private set; }
        public LinodeInstanceClient LinodeInstance { get; private set; }
        public LinodeTypeClient LinodeType { get; private set; }
        public RegionClient Region { get; private set; }
        public SshKeyClient SshKey { get; private set; }
        public StackScriptClient StackScript { get; private set; }
        public VolumeClient Volume { get; private set; }
    }
}
