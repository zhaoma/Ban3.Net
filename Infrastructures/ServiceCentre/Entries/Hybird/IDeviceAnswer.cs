// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 设备应答声明
/// </summary>
public interface IDeviceAnswer
{
    /// <summary>
    /// 应答字节组
    /// </summary>
    [JsonProperty( "data" )]
    byte[] Data { get; set; }
}