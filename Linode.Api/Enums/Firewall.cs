using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Linode.Api.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum eFirewallStatus
    {
        enabled,
        disabled,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eFirewallRulAction
    {
        ACCEPT,
        DROP,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum eFirewallProtocol
    {
        TCP,
        UDP,
        ICMP,
        IPENCAP,
    }
}
