using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

/// <summary>
/// 有日期的记录
/// </summary>
public interface IStockRecord
{
    /// <summary>
    /// 日期用yyyyMMdd格式的string
    /// </summary>
    string RecordDate { get; set; }
}

