//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using System;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// 分红解禁事件
/// </summary>
public  class Bonus:IBonus
{
    /// <summary>
    /// 除权日
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public int EventType { get; set; }

    /// <summary>
    /// 事件主题
    /// </summary>
    public string EventSubject { get; set; }

    /// <summary>
    /// 送股(每十股)
    /// </summary>
    public decimal Sbonus { get; set; }

    /// <summary>
    /// 转增(每十股)
    /// </summary>
    public decimal Zbonus { get; set; }

    /// <summary>
    /// 派息(每十股)
    /// </summary>
    public decimal Xmoney { get; set; }

    /// <summary>
    /// 配股(每十股)
    /// </summary>
    public decimal Pbonus { get; set; }

    /// <summary>
    /// 配股价格
    /// </summary>
    public decimal Pprice { get; set; }

    /// <summary>
    /// 基准股本
    /// </summary>
    public decimal Pcapital { get; set; }

    /// <summary>
    /// 解禁数量
    /// </summary>
    public decimal Lifted { get; set; }
}
