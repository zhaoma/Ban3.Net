//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

/// <summary>
/// Provides geographic coordinates and elevation of a location based on metadata contained within the file. 
/// If a driveItem has a non-null location facet, 
/// the item represents a file with a known location assocaited with it.
/// </summary>
public interface IGeoCoordinates
{
    /// <summary>
    /// 海拔
    /// </summary>
    [JsonProperty("altitude", NullValueHandling = NullValueHandling.Ignore)]
    double Altitude { get; set; }

    /// <summary>
    /// 维度
    /// </summary>
    [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
    double Latitude { get; }

    /// <summary>
    /// 经度
    /// </summary>
    [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
    double Longitude { get; set; }
}
