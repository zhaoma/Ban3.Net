using System;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries;

/// <summary>
/// 股东数据
/// </summary>
public class StockHolder
{
    /// <summary>
    /// Stock.Code
    /// </summary>
    [JsonProperty("SECUCODE")] public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Stock.Symbol
    /// </summary>
    [JsonProperty("SECURITY_CODE")] public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 股东代码
    /// </summary>
    [JsonProperty("ORG_CODE")] public string OrganizationCode { get; set; } = string.Empty;

    /// <summary>
    /// 报告期
    /// </summary>
    [JsonProperty("END_DATE")] public DateTime ReportDate { get; set; }

    /// <summary>
    /// 股东名称
    /// </summary>
    [JsonProperty("HOLDER_NAME")] public string HolderName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLD_NUM")] public double HoldNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("FREE_HOLDNUM_RATIO")] public double HoldRatioFree { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLD_NUM_CHANGE")] public string HoldChangeSubject { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("CHANGE_RATIO")] public double HoldChangeRatio { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("IS_HOLDORG")] public bool IsHoldOrganization { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLDER_RANK")] public int HoldRank { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("SECURITY_NAME_ABBR")] public string StockName { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLDER_CODE")] public string HolderCode { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("SECURITY_TYPE_CODE")] public string StockTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLDER_STATE")] public string HolderState { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLDER_MARKET_CAP")] public double HolderCapital { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLD_RATIO")] public double HoldRatio { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLD_RATIO_CHANGE")] public double HoldRatioChange { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLDER_TYPE")] public string HolderType { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("SHARES_TYPE")] public string SharesType { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("HOLDER_CODE_OLD")] public string HolderCodeOld { get; set; } = string.Empty;
}