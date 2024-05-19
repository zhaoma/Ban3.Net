using Ban3.Infrastructures.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Materials;

public interface ILocation
{
    /// <summary>
    /// 地址,The street address of the location.
    /// </summary>
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    IPhysicalAddress? Address { get; set; }

    /// <summary>
    /// The geographic coordinates and elevation of the location.
    /// </summary>
    [JsonProperty("coordinates", NullValueHandling = NullValueHandling.Ignore)]
    IGeoCoordinates? Coordinates { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
    string DisplayName { get; set; }

    /// <summary>
    /// 可选的电子邮件
    /// </summary>
    [JsonProperty("locationEmailAddress", NullValueHandling = NullValueHandling.Ignore)]
    string LocationEmailAddress { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("locationUri", NullValueHandling = NullValueHandling.Ignore)]
    string LocationUri { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("locationType", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    LocationType LocationType { get; set; }

    /*
     * 
     uniqueId	String	For internal use only.
     uniqueIdType	locationUniqueIdType	For internal use only.
     
     */
}
