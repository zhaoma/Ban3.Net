//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Ban3.Infrastructures.Contracts.Materials;

public interface ILocation : IZero
{
    /// <summary>
    /// 地址,The street address of the location.
    /// </summary>
    IPhysicalAddress? Address { get; set; }

    /// <summary>
    /// The geographic coordinates and elevation of the location.
    /// </summary>
    IGeoCoordinates? Coordinates { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    string DisplayName { get; set; }

    /// <summary>
    /// 可选的电子邮件
    /// </summary>
    string LocationEmailAddress { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string LocationUri { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    LocationType LocationType { get; set; }

    /*
     * 
     uniqueId	String	For internal use only.
     uniqueIdType	locationUniqueIdType	For internal use only.
     
     */
}
