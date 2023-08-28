using Ban3.Infrastructures.Common.Models;

namespace Ban3.Infrastructures.Indicators.Entries;

/// <summary>
/// 日期序列化格式
/// </summary>
public class TradeDateConverter : DateTimeConverter
{
    /// <summary>
    /// 用tushare习惯yyyyMMdd
    /// </summary>
    public TradeDateConverter()
        : base("yyyyMMdd")
    {
    }
}
