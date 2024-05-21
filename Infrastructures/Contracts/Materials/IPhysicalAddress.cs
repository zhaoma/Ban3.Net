//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.Contracts.Materials;

public interface IPhysicalAddress : IZero
{
    /// <summary>
    /// 地址的类型
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    PhysicalAddressType Type { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    string City { get; set; }

    /// <summary>
    /// 国家与地区
    /// It's a free-format string value, for example, "United States".
    /// </summary>
    string CountryOrRegion { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    string PostalCode { get; set; }

    /// <summary>
    /// 邮政信箱
    /// </summary>
    string PostOfficeBox { get; set; }

    /// <summary>
    /// 州县
    /// </summary>
    string State { get; set; }

    /// <summary>
    /// 街道地址
    /// </summary>
    string Street { get; set; }
}
