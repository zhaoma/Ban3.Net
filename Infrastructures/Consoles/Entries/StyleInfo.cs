// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Consoles.Entries;

/// <summary>
/// 表格显示样式信息
/// 通过 Format 获取到的
/// </summary>
public class StyleInfo
{
    /// <summary>
    /// 样式（线条）
    /// </summary>
    /// <param name="delimiterStr"></param>
    /// <param name="rowHasBorder"></param>
    /// <param name="angleStr"></param>
    public StyleInfo(string delimiterStr = "|", bool rowHasBorder = true, string angleStr = "-")
    {
        DelimiterStr = delimiterStr;
        RowHasBorder = rowHasBorder;
        AngleStr = angleStr;
    }

    /// <summary>
    /// 每一列数据之间的间隔字符串
    /// </summary>
    public string DelimiterStr { get; set; }

    /// <summary>
    /// 是否显示顶部，底部，和每一行数据之间的横向边框
    /// </summary>
    public bool RowHasBorder { get; set; }

    /// <summary>
    /// 边角字符串
    /// </summary>
    public string AngleStr { get; set; }
}
