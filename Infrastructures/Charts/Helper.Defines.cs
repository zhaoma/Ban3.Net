// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;

namespace Ban3.Infrastructures.Charts;

/// <summary>
/// 常用颜色与icon示例
/// </summary>
public static partial class Helper
{
    public const string White = "#FFF";
    public const string Yellow = "#FC0";
    public const string Purple = "#C09";
    public const string Green = "#3C0";
    public const string Gray = "#CCC";
    public const string Red = "#F00";

    /// <summary>
    /// $
    /// </summary>
    /// <param name="name"></param>
    /// <param name="xy"></param>
    /// <returns></returns>
    public static GeneralData DotOfSelling(
        string name,
        object[] xy)
    {
        return new GeneralData(
            name,
            xy,
            "",
            @"path://M4 10.781c.148 1.667 1.513 2.85 3.591 3.003V15h1.043v-1.216c2.27-.179 3.678-1.438 3.678-3.3 0-1.59-.947-2.51-2.956-3.028l-.722-.187V3.467c1.122.11 1.879.714 2.07 1.616h1.47c-.166-1.6-1.54-2.748-3.54-2.875V1H7.591v1.233c-1.939.23-3.27 1.472-3.27 3.156 0 1.454.966 2.483 2.661 2.917l.61.162v4.031c-1.149-.17-1.94-.8-2.131-1.718H4zm3.391-3.836c-1.043-.263-1.6-.825-1.6-1.616 0-.944.704-1.641 1.8-1.828v3.495l-.2-.05zm1.591 1.872c1.287.323 1.852.859 1.852 1.769 0 1.097-.826 1.828-2.2 1.939V8.73l.348.086z",
            new [] { 16, 16 },
            new GeneralStyle { Color = Purple }
        );
    }

    /// <summary>
    /// B
    /// </summary>
    /// <param name="name"></param>
    /// <param name="xy"></param>
    /// <returns></returns>
    public static GeneralData DotOfBuying(
        string name,
        object[] xy)
    {
        return new GeneralData(
            name,
            xy,
            "",
            @"path://M8.21 13c2.106 0 3.412-1.087 3.412-2.823 0-1.306-.984-2.283-2.324-2.386v-.055a2.176 2.176 0 0 0 1.852-2.14c0-1.51-1.162-2.46-3.014-2.46H3.843V13H8.21zM5.908 4.674h1.696c.963 0 1.517.451 1.517 1.244 0 .834-.629 1.32-1.73 1.32H5.908V4.673zm0 6.788V8.598h1.73c1.217 0 1.88.492 1.88 1.415 0 .943-.643 1.449-1.832 1.449H5.907z",
            new [] { 16, 16 },
            new GeneralStyle { Color = Yellow }
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="xy"></param>
    /// <returns></returns>
    public static GeneralData DotOfNotice(
        string name,
        object[] xy)
    {
        return new GeneralData(
            name,
            xy,
            "",
            @"path://M9.5 12.5a1.5 1.5 0 1 1-2-1.415V6.5a.5.5 0 0 1 1 0v4.585a1.5 1.5 0 0 1 1 1.415z M5.5 2.5a2.5 2.5 0 0 1 5 0v7.55a3.5 3.5 0 1 1-5 0V2.5zM8 1a1.5 1.5 0 0 0-1.5 1.5v7.987l-.167.15a2.5 2.5 0 1 0 3.333 0l-.166-.15V2.5A1.5 1.5 0 0 0 8 1z",
            new [] { 16, 16 },
            new GeneralStyle { Color = Yellow }
        );
    }

    /// <summary>
    /// https://icons.getbootstrap.com/icons/dot/
    /// </summary>
    /// <param name="name"></param>
    /// <param name="xy"></param>
    /// <param name="size"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    public static GeneralData Dot(
        string name,
        object[] xy,
        int[] size,
        string color)
    {
        return new GeneralData(
            name,
            xy,
            "",
            @"path://M8 9.5a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3z",
            size,
            new GeneralStyle { Color = color }
        );
    }
}