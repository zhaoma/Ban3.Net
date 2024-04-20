//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// 分红除权信息
/// </summary>
public interface IBonus
{
    /// <summary>
    /// 除权日
    /// </summary>
    DateTime MarkTime { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    int EventType { get; set; }

    /// <summary>
    /// 事件主题
    /// </summary>
    string EventSubject { get; set; }

    /// <summary>
    /// 送股(每十股)
    /// </summary>
    decimal Sbonus { get; set; }

    /// <summary>
    /// 转增(每十股)
    /// </summary>
    decimal Zbonus { get; set; }

    /// <summary>
    /// 派息(每十股)
    /// </summary>
    decimal Xmoney { get; set; }

    /// <summary>
    /// 配股(每十股)
    /// </summary>
    decimal Pbonus { get; set; }

    /// <summary>
    /// 配股价格
    /// </summary>
    decimal Pprice { get; set; }

    /// <summary>
    /// 基准股本
    /// </summary>
    decimal Pcapital { get; set; }

    /// <summary>
    /// 解禁数量
    /// </summary>
    decimal Lifted { get; set; }
}
