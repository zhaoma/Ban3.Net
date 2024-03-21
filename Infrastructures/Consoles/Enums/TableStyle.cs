// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.Consoles.Enums;

/// <summary>
/// 表格显示样式
/// </summary>
public enum TableStyle
{
    /// <summary>
    /// 默认格式的表格
    /// </summary>
    [Description("Default")]
    Default = 0,

    /// <summary>
    /// Markdwon格式的表格
    /// </summary>
    [Description("MarkDown")]
    MarkDown = 1,

    /// <summary>
    /// 交替格式的表格
    /// </summary>
    [Description("Alternative")]
    Alternative = 2,

    /// <summary>
    /// 最简格式的表格
    /// </summary>
    [Description("Minimal")]
    Minimal = 3
}