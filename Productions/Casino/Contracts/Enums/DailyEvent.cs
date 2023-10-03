using System;
using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 
/// </summary>
public enum DailyEvent
{
    /// <summary>
    /// 
    /// </summary>
    [Description("常规")]
    Normal,
    /// <summary>
    /// 
    /// </summary>
    [Description("涨停")]
    LimitUp,
    /// <summary>
    /// 
    /// </summary>
    [Description("日平均线金叉")]
    MacdDailyGC,
    /// <summary>
    /// 
    /// </summary>
    [Description("日平均线上穿")]
    MacdDailyC0,
    /// <summary>
    /// 
    /// </summary>
    [Description("周平均线上穿")]
    MacdWeeklyC0,
    /// <summary>
    /// 
    /// </summary>
    [Description("月平均线上穿")]
    MacdMonthlyC0,
    /// <summary>
    /// 
    /// </summary>
    [Description("跌停")]
    LimitDown
}

