/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            外键属性
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Attributes;

/// <summary>
/// 外键字段属性
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class ForeignKeyAttribute : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public ForeignKeyAttribute()
    {
    }

    /// <summary>
    /// 转字符格式
    /// </summary>
    public Type? Referer { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="referer"></param>
    public ForeignKeyAttribute(Type referer)
    {
        Referer = referer;
    }
}