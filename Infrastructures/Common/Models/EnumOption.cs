// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 枚举转选项定义
/// </summary>
public class EnumOption
{
    /// <summary>
    /// 标签类型
    /// </summary>
    public string TagType { get; set; } = string.Empty;

    /// <summary>
    /// 枚举描述
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 枚举名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 枚举值
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// 图标颜色
    /// </summary>
    public string IconColor { get; set; } = string.Empty;

    /// <summary>
    /// 别名(英文值)
    /// </summary>
    public string Alias { get; set; } = string.Empty;
}