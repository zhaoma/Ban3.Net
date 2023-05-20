using System;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaNetease.Entries;

/// <summary>
/// 历史价格信息
/// </summary>
public class StockPrice
{
    /*         
    日期,股票代码,名称,
    收盘价,最高价,最低价,开盘价,前收盘,涨跌额,涨跌幅,换手率,成交量,成交金额,总市值,流通市值
     */

    /// <summary>
    /// 日期yyyy-MM-dd
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public string Symbal { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

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
    /// 开盘价
    /// </summary>
    public decimal Open { get; set; }

    /// <summary>
    /// 前收盘
    /// </summary>
    public decimal CloseBefore { get; set; }

    /// <summary>
    /// 涨幅(金额)
    /// </summary>
    public decimal Change { get; set; }

    /// <summary>
    /// 涨幅
    /// </summary>
    public decimal ChangeRatio { get; set; }

    /// <summary>
    /// 换手率
    /// </summary>
    public decimal TurnoverRate { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    public double Volume { get; set; }

    /// <summary>
    /// 交易额
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// 总市值
    /// </summary>
    public double TotalValue { get; set; }

    /// <summary>
    /// 流通市值
    /// </summary>
    public double TradableValue { get; set; }

    public StockPrice()
    {
    }

    public StockPrice(string neteaseRow)
    {
        var cols = neteaseRow.Split(',');

        Date = cols[0].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime();
        Symbal = cols[1].Replace("'", "").Trim();
        Name = (cols[2] + "").Trim();
        Close = cols[3].ToDecimal();
        High = cols[4].ToDecimal();
        Low = cols[5].ToDecimal();
        Open = cols[6].ToDecimal();
        CloseBefore = cols[7].ToDecimal();
        Change = cols[8].ToDecimal();
        ChangeRatio = cols[9].ToDecimal();
        TurnoverRate = cols[10].ToDecimal();
        Volume = cols[11].ToDouble();
        Amount = cols[12].ToDouble();
        TotalValue = cols[13].ToDouble();
        TradableValue = cols[14].ToDouble();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string ToRowString()
    {
        return
            $"{Date.ToString("yyyy-MM-dd")},{Symbal},{Name},{Close},{High},{Low},{Open},{CloseBefore},{Change},{ChangeRatio},{TurnoverRate},{Volume},{Amount},{TotalValue},{TradableValue}";
    }
}