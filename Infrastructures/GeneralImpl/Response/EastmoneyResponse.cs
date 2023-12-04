//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Text;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using Newtonsoft.Json;

namespace Ban3.Infrastructures.GeneralImpl.Response;

/// 
public class EastmoneyResponse
{
    /// 
    public static IEnumerable<IStockHolder> ResultToHolders(
        IInternetResponse callback,
        InternetResource resource
    )
    {
        Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );

        var response = callback.Response.StringContent
                               .JsonpParse( resource.JsonpPrefix )
                               .JsonToObj<ApiResponse>();

        return new List<IStockHolder>();
    }

    /// <summary>
    /// 响应数据包
    /// </summary>
    internal class ApiResponse
    {
        [JsonProperty( "version" )]
        public string Version { get; set; }

        [JsonProperty( "result" )]
        public ApiResult Result { get; set; }

        [JsonProperty( "success" )]
        public bool Success { get; set; }

        [JsonProperty( "message" )]
        public string Message { get; set; }

        [JsonProperty( "code" )]
        public int Code { get; set; }
    }

    /// <summary>
    /// 数据
    /// </summary>
    internal class ApiResult
    {
        [JsonProperty( "pages" )]
        public int Pages { get; set; }

        [JsonProperty( "data" )]
        public List<ApiItem> Data { get; set; }

        [JsonProperty( "count" )]
        public int Count { get; set; }
    }

    /// <summary>
    /// 数据项
    /// </summary>
    internal class ApiItem
    {
        /// <summary>
        /// e.g.301215.SZ
        /// </summary>
        [JsonProperty( "SECUCODE" )]
        public string Code { get; set; }

        /// <summary>
        /// e.g.301215
        /// </summary>
        [JsonProperty( "SECURITY_CODE" )]
        public string Symbol { get; set; }

        /// <summary>
        /// e.g.10000089817
        /// </summary>
        [JsonProperty( "ORG_CODE" )]
        public string OrgCode { get; set; }

        /// <summary>
        /// "2023-09-30 00:00:00"
        /// </summary>
        [JsonProperty( "END_DATE" )]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// "江苏悦达集团有限公司"
        /// </summary>
        [JsonProperty( "HOLDER_NAME" )]
        public string HolderName { get; set; }

        /// <summary>
        /// 386800000
        /// </summary>
        [JsonProperty( "HOLD_NUM" )]
        public long HoldNum { get; set; }

        /// <summary>
        /// 50.403961428199
        /// </summary>
        [JsonProperty( "FREE_HOLDNUM_RATIO" )]
        public decimal FreeHoldNumRatio { get; set; }

        /// <summary>
        /// "不变"
        /// </summary>
        [JsonProperty( "HOLD_NUM_CHANGE" )]
        public string HoldNumChange { get; set; }

        /// <summary>
        /// null
        /// </summary>
        [JsonProperty( "CHANGE_RATIO" )]
        public decimal ChangeRatio { get; set; }

        /// <summary>
        /// "1"
        /// </summary>
        [JsonProperty( "IS_HOLDORG" )]
        public string IsHoldOrg { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [JsonProperty( "HOLDER_RANK" )]
        public int HolderRank { get; set; }

        /// <summary>
        /// "中汽股份"
        /// </summary>
        [JsonProperty( "SECURITY_NAME_ABBR" )]
        public string SecurityNameAbbr { get; set; }

        /// <summary>
        /// "10005295"
        /// </summary>
        [JsonProperty( "HOLDER_CODE" )]
        public string HolderCode { get; set; }

        /// <summary>
        /// "058001001"
        /// </summary>
        [JsonProperty( "SECURITY_TYPE_CODE" )]
        public string SecurityTypeCode { get; set; }

        /// <summary>
        /// null
        /// </summary>
        [JsonProperty( "HOLDER_STATE" )]
        public string HolderState { get; set; }

        /// <summary>
        /// 2328536000
        /// </summary>
        [JsonProperty( "HOLDER_MARKET_CAP" )]
        public long HolderMarketCap { get; set; }

        /// <summary>
        /// 29.2498
        /// </summary>
        [JsonProperty( "HOLD_RATIO" )]
        public decimal HoldRatio { get; set; }

        /// <summary>
        /// "不变"
        /// </summary>
        [JsonProperty( "HOLD_CHANGE" )]
        public string HoldChange { get; set; }

        /// <summary>
        /// 0
        /// </summary>
        [JsonProperty( "HOLD_RATIO_CHANGE" )]
        public decimal HoldRatioChange { get; set; }

        /// <summary>
        /// "其它"
        /// </summary>
        [JsonProperty( "HOLDER_TYPE" )]
        public string HolderType { get; set; }

        /// <summary>
        /// "A股"
        /// </summary>
        [JsonProperty( "SHARES_TYPE" )]
        public string SharesType { get; set; }

        /// <summary>
        /// "2023-10-20 00:00:00"
        /// </summary>
        [JsonProperty( "UPDATE_DATE" )]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// "2023三季报"
        /// </summary>
        [JsonProperty( "REPORT_DATE_NAME" )]
        public string ReportDateName { get; set; }

        /// <summary>
        /// "10005295"
        /// </summary>
        [JsonProperty( "HOLDER_NEW" )]
        public string HolderNew { get; set; }

        /// <summary>
        /// "不变"
        /// </summary>
        [JsonProperty( "FREE_RATIO_QOQ" )]
        public string FreeRatioQoq { get; set; }

        /// <summary>
        /// "1"
        /// </summary>
        [JsonProperty( "IS_REPORT" )]
        public string IsReport { get; set; }

        /// <summary>
        /// "80006970"
        /// </summary>
        [JsonProperty( "HOLDER_CODE_OLD" )]
        public string HolderCodeOld { get; set; }

        /// <summary>
        /// "其他"
        /// </summary>
        [JsonProperty( "HOLDER_NEWTYPE" )]
        public string HolderNewType { get; set; }

        /// <summary>
        /// "不变"
        /// </summary>
        [JsonProperty( "HOLDNUM_CHANGE_NAME" )]
        public string HoldNumChangeName { get; set; }

        /// <summary>
        /// "1"
        /// </summary>
        [JsonProperty( "IS_MAX_REPORTDATE" )]
        public string IsMaxReportDate { get; set; }

        /// <summary>
        /// "10005295"
        /// </summary>
        [JsonProperty( "COOPERATION_HOLDER_MARK" )]
        public string CooperationHolderMark { get; set; }

        /// <summary>
        /// "88258e3be0a08cc30fafbcd3b3539108"
        /// </summary>
        [JsonProperty( "MXID" )]
        public string MxId { get; set; }

        /// <summary>
        /// "0"
        /// </summary>
        [JsonProperty( "LISTING_STATE" )]
        public string ListingState { get; set; }

        /// <summary>
        /// 0
        /// </summary>
        [JsonProperty( "XZCHANGE" )]
        public long XzChange { get; set; }

        /// <summary>
        /// "不变"
        /// </summary>
        [JsonProperty( "NEW_CHANGE_RATIO" )]
        public string NewChangeRatio { get; set; }

        /// <summary>
        /// "不变"
        /// </summary>
        [JsonProperty( "HOLDER_STATE_NEW" )]
        public string HolderStateNew { get; set; }

        /// <summary>
        /// "ee290dc2-f7a2-4c21-8dfb-300b9bd3fa78"
        /// </summary>
        [JsonProperty( "HOLD_ORG_CODE_SOURCE" )]
        public string HoldOrgCodeSource { get; set; }
    }
}