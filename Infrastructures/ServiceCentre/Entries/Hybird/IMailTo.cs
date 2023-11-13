// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 邮件地址声明
/// </summary>
public interface IMailTo
{
    /// <summary>
    /// 电子邮件地址
    /// </summary>
    [JsonProperty("email")]
    string Email { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonProperty("name")]
    string Name { get; set; }
}