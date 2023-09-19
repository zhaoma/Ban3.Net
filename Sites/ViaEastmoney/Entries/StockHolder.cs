using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaEastmoney.Entries;

/// <summary>
/// 股东数据
/// </summary>
[Serializable, DataContract]
public class StockHolder
{
	[JsonProperty("SECUCODE")]
	public string Code { get; set; } = string.Empty;


    [JsonProperty("SECURITY_CODE")]
	public string Symbol{get;set;}=string.Empty;


    [JsonProperty("ORG_CODE")]
	public string OrganizationCode{get;set;}=string.Empth;

    [JsonProperty("END_DATE")]
	public DateTime REportDate{get;set;}

	[JsonProperty("HOLDER_NAME")]
	public string HolderName{get;set;}
	
	
[JsonProperty(		"HOLD_NUM")]
public double HoldNumber{get;set;}
[JsonProperty(		"FREE_HOLDNUM_RATIO")]
public double HoldRatioFree{get;set;}

[JsonProperty(		"HOLD_NUM_CHANGE")]
public string HoldChangeSubject{get;set;}

[JsonProperty(		"CHANGE_RATIO")]
public double HoldChangeRatio{get;set;}


[JsonProperty(		"IS_HOLDORG")]
public bool IsHoldOrganization{get;set;}

[JsonProperty(		"HOLDER_RANK")]
public int HoldRank{get;set;}


[JsonProperty(		"SECURITY_NAME_ABBR")]
public string StockName{get;set;}

[JsonProperty(		"HOLDER_CODE")]
public string HolderCode{get;set;}


	[JsonProperty(	"SECURITY_TYPE_CODE")]
	public string StockTypeCode{get;set;}

	
[JsonProperty(		"HOLDER_STATE": null,
[JsonProperty(		"HOLDER_MARKET_CAP": 389490530.32,
[JsonProperty(		"HOLD_RATIO": 13.7524,
[JsonProperty(		"HOLD_CHANGE": "不变",
	[JsonProperty(	"HOLD_RATIO_CHANGE": 0,
[JsonProperty(		"HOLDER_TYPE": "其它",
[JsonProperty(	"SHARES_TYPE": "A股",
[JsonProperty("UPDATE_DATE": "2023-09-16 00:00:00",
[JsonProperty("REPORT_DATE_NAME": "2023-09-14",
[JsonProperty("HOLDER_NEW": "10501094",

    [JsonProperty("FREE_RATIO_QOQ": "不变",

    [JsonProperty("HOLDER_STATEE": null,

    [JsonProperty("IS_REPORT": "0",

    [JsonProperty("HOLDER_CODE_OLD": "80469310",

    [JsonProperty("HOLDER_NEWTYPE": "其他",

    [JsonProperty("HOLDNUM_CHANGE_NAME": "不变",

    [JsonProperty("IS_MAX_REPORTDATE": "1",

    [JsonProperty("COOPERATION_HOLDER_MARK": "10501094",

    [JsonProperty("MXID": "2981ee9332165d66c03e8d38d0206a03",

    [JsonProperty("LISTING_STATE": "0",

    [JsonProperty("XZCHANGE": 0,

    [JsonProperty("NEW_CHANGE_RATIO": "不变"
}