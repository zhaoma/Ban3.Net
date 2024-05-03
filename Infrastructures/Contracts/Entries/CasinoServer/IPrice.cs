//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino价格信息
/// </summary>
public interface IPrice
{
    /// <summary>
    /// 编码
    /// </summary>
    string Code { get; set; }

    /// <summary>
    /// 行情时间(日，周月最后交易日)
    /// </summary>
    DateTime MarkTime { get;  }

    /// <summary>
    /// 
    /// </summary>
    string TradeDate { get; set; }

    /// <summary>
    /// 前收
    /// </summary>
    decimal PreClose { get; set; }

    /// <summary>
    /// 开盘价
    /// </summary>
    decimal Open {  get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    decimal Close { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    decimal High {  get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    decimal Low { get; set; }
    decimal Change { get; set; }

    decimal ChangePercent { get; set; }
    /// <summary>
    /// 交易量
    /// </summary>
    decimal Volumn { get; set; }

    /// <summary>
    /// 交易额
    /// </summary>
    decimal Amount { get; set; }

    /// <summary>
    /// 换手率
    /// </summary>
    decimal Turnover { get; set; }
}
