﻿using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 周期定义，日周月，M60
/// </summary>
public enum AnalysisCycle
{
    /// <summary>
    /// 日线
    /// </summary>
    [Description("日线")]
    DAILY = 1,

    /// <summary>
    /// 周线
    /// </summary>
    [Description("周线")]
    WEEKLY = 2,

    /// <summary>
    /// 月线
    /// </summary>
    [Description("月线")]
    MONTHLY = 3
}
