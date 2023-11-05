// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Consoles.Entries;

namespace Ban3.Infrastructures.Consoles;

/// <summary>
/// 控制台扩展方法
/// </summary>
public static class Helper
{
    static readonly object ObjLock = new();

    /// <summary>
    /// 在控制台输出
    /// </summary>
    /// <param name="str">文本</param>
    /// <param name="color">前颜色</param>
    public static void WriteColorLine(this string str, ConsoleColor color)
    {
        lock (ObjLock)
        {
            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = currentForeColor;
        }
    }

    /// <summary>
    /// 打印错误信息
    /// </summary>
    /// <param name="str">待打印的字符串</param>
    /// <param name="color">想要打印的颜色</param>
    public static void WriteErrorLine(this string str, ConsoleColor color = ConsoleColor.Red) => str.WriteColorLine(color);

    /// <summary>
    /// 打印警告信息
    /// </summary>
    /// <param name="str">待打印的字符串</param>
    /// <param name="color">想要打印的颜色</param>
    public static void WriteWarningLine(this string str, ConsoleColor color = ConsoleColor.Yellow) => str.WriteColorLine(color);

    /// <summary>
    /// 打印正常信息
    /// </summary>
    /// <param name="str">待打印的字符串</param>
    /// <param name="color">想要打印的颜色</param>
    public static void WriteInfoLine(this string str, ConsoleColor color = ConsoleColor.Gray) => str.WriteColorLine(color);

    /// <summary>
    /// 打印成功的信息
    /// </summary>
    /// <param name="str">待打印的字符串</param>
    /// <param name="color">想要打印的颜色</param>
    public static void WriteSuccessLine(this string str, ConsoleColor color = ConsoleColor.Green) => str.WriteColorLine(color);

    /// <summary>
    /// 实体集合输出ConsoleTable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ts"></param>
    /// <returns></returns>
    public static ConsoleTable ConsoleTable<T>(this IEnumerable<T> ts)
        => Entries.ConsoleTable.From(ts);
}
