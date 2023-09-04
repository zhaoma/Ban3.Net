﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（枚举）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Models;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 枚举操作
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 获取到对应枚举的描述-没有描述信息，返回枚举值
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static string EnumDescription(this Enum @enum)
    {
        if (!(Attribute.GetCustomAttribute(@enum.GetType().GetField(nameof(@enum)), typeof(DescriptionAttribute)) is
                DescriptionAttribute attribute))
        {
            return @enum.ToString();
        }

        return attribute.Description;
    }

    /// <summary>
    /// 枚举转列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<EnumOption> EnumOptions<T>()
    {
        return typeof(T).EnumOptions();
    }

    /// <summary>
    /// 枚举转列表
    /// </summary>
    /// <param name="enumType"></param>
    /// <returns></returns>
    public static List<EnumOption> EnumOptions(this Type enumType)
    {
        var options = new List<EnumOption>();
        foreach (var e in Enum.GetValues(enumType))
        {
            var m = new EnumOption();
            object[] attachedAttributes = e.GetType()
                .GetField(e.ToString())
                .GetCustomAttributes(typeof(EnumAttachedAttribute), true);

            if (attachedAttributes.Length > 0)
            {
                var aa = attachedAttributes[0] as EnumAttachedAttribute;

                m.TagType = aa!.TagType;
                m.Description = aa.Description;
                m.Icon = aa.Icon;
                m.IconColor = aa.IconColor;
            }

            m.Value = Convert.ToInt32(e);
            m.Name = e.ToString();
            options.Add(m);
        }

        return options;
    }

    /// <summary>
    /// 定义值转枚举(大小写敏感)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="val"></param>
    /// <returns></returns>
    public static T StringToEnum<T>(this string val) where T : Enum
    {
        return (T)Enum.Parse(typeof(T), val);
    }

    /// <summary>
    /// 枚举转枚举
    /// </summary>
    /// <typeparam name="TOld"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <param name="inVal"></param>
    /// <returns></returns>
    public static TNew EnumToEnum<TOld, TNew>(this TOld inVal)
        where TOld : Enum
        where TNew : struct
    {
        var success = Enum.TryParse<TNew>($"{inVal}", out var result);

        return !success ? default(TNew) : result;
    }
}