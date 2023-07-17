using System;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 复权因子集合
/// </summary>
public class StockSeed
{
    /// <summary>
    /// 日期
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 复权因子
    /// </summary>
    public float Seed { get; set; }
}