/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            枚举类型关联属性
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Attributes;

/// <summary>
/// 枚举类型关联属性
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true)]
public class EnumAttachedAttribute : Attribute
{
    /// <summary>
    /// 标签类型 样式
    /// </summary>
    public string TagType { get; set; } = string.Empty;

    /// <summary>
    /// 中文描述
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// 图标颜色
    /// </summary>
    public string IconColor { get; set; } = string.Empty;
}