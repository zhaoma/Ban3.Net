using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

/// <summary>
/// 基础信息
/// https://tushare.pro/document/2?doc_id=25
/// </summary>
public class StockBasic
{
    [JsonIgnore] 
    public List<string> RequestFields = new()
    {
        "ts_code", "symbol", "name", "list_date"
    };

    /// <summary>
    /// TS代码
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 股票代码
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 股票名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 上市日期
    /// </summary>
    public string ListDate { get; set; } = string.Empty;

    public StockBasic(){}

    public StockBasic(List<string> row)
    {
        Code = row[0];
        Symbol = row[1];
        Name = row[2];
        ListDate = row[3];
    }
}