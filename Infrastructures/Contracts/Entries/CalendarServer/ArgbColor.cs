﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;
using System.Globalization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 颜色结构定义
/// </summary>
public class ArgbColor : IZero
{
    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="argbValue"></param>
    public ArgbColor(int argbValue)
    {
        _argbValue = argbValue;
    }

    private int _argbValue;

    /// <summary>
    /// 颜色整数值
    /// </summary>
    public int ArgbValue
    {
        get { return _argbValue; }
        set { _argbValue = value; }
    }

    /// <summary>
    /// 数字转换成颜色
    /// </summary>
    /// <param name="rgb"></param>
    /// <returns></returns>
    public static ArgbColor FromRgb(int rgb)
    {
        return new ArgbColor(0xff << 24 | rgb);
    }

    /// <summary>
    /// 16进制字符串转换成颜色
    /// </summary>
    /// <param name="rgba"></param>
    /// <returns></returns>
    public static ArgbColor FromRgbaHexStringWithOptionalANoThrow(string rgba)
    {
        return new ArgbColor(HexToArgbColor(rgba));
    }

    /// <summary>
    /// 转换成16进制字符串
    /// </summary>
    /// <returns></returns>
    public string ToRgbaHexString()
    {
        var rbga = _argbValue << 8 | 0x000000ff & _argbValue >> 24;
        return $"#{Convert.ToString(rbga, 16)}";
    }

    private static int HexToArgbColor(string rgba)
    {
        try
        {
            string color = rgba.Replace("#", "");
            byte r = Byte.Parse(color.Substring(0, 2), NumberStyles.HexNumber);
            byte g = Byte.Parse(color.Substring(2, 2), NumberStyles.HexNumber);
            byte b = Byte.Parse(color.Substring(4, 2), NumberStyles.HexNumber);
            byte a = (color.Length == 8) ? Byte.Parse(color.Substring(6, 2), NumberStyles.HexNumber) : Convert.ToByte(255);

            return a << 24 | r << 16 | g << 8 | b;
        }
        catch (Exception x)
        {
            // Return gray if caldav color is invalid
            return 0xff << 24 | 0x808080;
        }
    }
}
