// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 设备指令声明
/// </summary>
public interface IDeviceControl
{
    /// <summary>
    /// 指令字节组
    /// </summary>
    [JsonProperty("codes")]
    byte[] Codes { get; set; }

}

