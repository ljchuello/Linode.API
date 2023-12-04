using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Linode.Api.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DomainType
    {
        master,
        slave,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DomainStatus
    {
        disabled,
        active,
    }
}
