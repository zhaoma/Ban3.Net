//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.Contracts.Materials;

public interface IPhysicalAddress
{
    /// <summary>
    /// 地址的类型
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    PhysicalAddressType Type { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
    string City { get; set; }

    /// <summary>
    /// 国家与地区
    /// It's a free-format string value, for example, "United States".
    /// </summary>
    [JsonProperty("countryOrRegion", NullValueHandling = NullValueHandling.Ignore)]
    string CountryOrRegion { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
    string PostalCode { get; set; }

    /// <summary>
    /// 邮政信箱
    /// </summary>
    [JsonProperty("postOfficeBox", NullValueHandling = NullValueHandling.Ignore)]
    string PostOfficeBox { get; set; }

    /// <summary>
    /// 州县
    /// </summary>
    [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
    string State { get; set; }

    /// <summary>
    /// 街道地址
    /// </summary>
    [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
    string Street { get; set; }
}
