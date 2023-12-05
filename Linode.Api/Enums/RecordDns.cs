using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Linode.Api.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecordDnsType
    {
        A,
        AAAA,
        NS,
        MX,
        CNAME,
        TXT,
        SRV,
        PTR,
        CAA,
    }
}
