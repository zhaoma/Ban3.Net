// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 设备节点声明
/// </summary>
public interface IDeviceEndpoint
{
    /// <summary>
    /// 设备所在
    /// </summary>
    [JsonProperty("deviceAt")]
    [JsonConverter(typeof(StringEnumConverter))]
    DeviceAt DeviceAt { get; set; }

    /// <summary>
    /// 波特率
    /// </summary>
    [JsonProperty("deviceBoundary")]
    [JsonConverter(typeof(StringEnumConverter))]
    DeviceBoundary DeviceBoundary { get; set; }

    /// <summary>
    /// 使用端口
    /// </summary>
    [JsonProperty("port")]
    int Port { get; set; }
}

