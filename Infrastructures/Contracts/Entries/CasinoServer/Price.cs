//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino价格信息
/// </summary>
public class Price : IZero
{
    /// <summary>
    /// 编码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 行情时间(日，周月最后交易日)
    /// </summary>
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? TradeDate { get; set; }

    /// <summary>
    /// 前收
    /// </summary>
    public decimal PreClose { get; set; }

    /// <summary>
    /// 开盘价
    /// </summary>
    public decimal Open { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    public decimal Close { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    public decimal High { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    public decimal Low { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public decimal Change { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public decimal ChangePercent { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    public decimal Volumn { get; set; }

    /// <summary>
    /// 交易额
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 换手率
    /// </summary>
    public decimal Turnover { get; set; }
}
