using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// 请求响应结果
/// </summary>
public enum HttpStatus
{
    [Description("OK")]
    Ok,

    [Description("ERROR")]
    Error
}

