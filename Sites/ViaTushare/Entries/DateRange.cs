using System;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaTushare.Entries;

/// <summary>
/// 查询使用的日期区间
/// </summary>
public class DateRange
{
    /// <summary>
    /// 默认最近一个月
    /// </summary>
    public DateRange()
    {
        StartDate = DateTime.Now.AddMonths(-1).ToYmd();
        EndDate = DateTime.Now.ToYmd();
    }

    /// <summary>
    /// days以内
    /// </summary>
    /// <param name="days"></param>
    public DateRange(int days)
    {
        StartDate = DateTime.Now.AddDays(-days).ToYmd();
        EndDate = DateTime.Now.ToYmd();
    }

    /// <summary>
    /// 第freq个years年 
    /// </summary>
    /// <param name="years"></param>
    /// <param name="freq"></param>
    public DateRange(int years, int freq)
    {
        var endDate = DateTime.Now.AddYears(-freq * years);
        var startDate = endDate.AddYears(-years);

        StartDate = startDate.ToYmd();
        EndDate = endDate.ToYmd();
    }

    /// <summary>
    /// 查询日期格式yyyyMMdd
    /// </summary>
    public string StartDate { get; set; }

    /// <summary>
    /// 查询日期格式yyyyMMdd
    /// </summary>
    public string EndDate { get; set; }
}
