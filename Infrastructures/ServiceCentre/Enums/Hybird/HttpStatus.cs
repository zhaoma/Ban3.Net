// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// 请求响应结果
/// </summary>
public enum HttpStatus
{
    /// <summary />
    [Description("OK")]
    Ok,

    /// <summary />
    [Description("ERROR")]
    Error
}

