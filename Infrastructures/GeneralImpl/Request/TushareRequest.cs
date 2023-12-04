// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Request;

/// 
public class TushareRequest
{
    /// 
    public static InternetResource ResourceForCodes()
    {
        return new InternetResource
        {
            Method = HttpMethod.Post,
            Url = @"http://api.tushare.pro",
            Request = new InternetData
            {
                ContentEncoding = "UTF-8",
                StringContent = new ApiRequestBody
                {
                    ApiName = "stock_basic",
                    FieldList =
                    {
                        "ts_code", "symbol", "name", "list_date"
                    }
                }.ObjToJson()
            }
        };
    }

    /// 
    public static InternetResource ResourceForPrices( IStock stock )
    {
        return new InternetResource
        {
            Method = HttpMethod.Post,
            Url = @"http://api.tushare.pro",
            Request = new InternetData
            {
                StringContent = new ApiRequestBody
                {
                    ApiName = "daily",
                    FieldList =
                    {
                        "ts_code", "trade_date", "open", "high", "low", "close", "pre_close", "change", "pct_chg", "vol", "amount"
                    },
                    Params = new GetDailyParams
                    {
                        Code = stock.Code
                    }.ToDictionary()
                }.ObjToJson()
            }
        };
    }

    /// 
    internal class ApiRequestBody
    {
        /// 
        [JsonProperty( "api_name" )]
        public string ApiName { get; set; } = string.Empty;

        /// 
        [JsonProperty( "token" )]
        public string Token { get; set; }

        /// 
        [JsonProperty( "params", NullValueHandling = NullValueHandling.Ignore )]
        public Dictionary<string, object>? Params { get; set; }

        /// 
        [JsonProperty( "fields" )]
        public string Fields => string.Join( ",", FieldList );

        /// 
        [JsonIgnore]
        public List<string> FieldList { get; set; } = new();

        /// 
        public ApiRequestBody()
        {
            var token = Common.Config.GetValue( "Sites:TushareToken" );
            if( string.IsNullOrEmpty( token ) )
            {
                token = @"dac6b901ec28c2fd99e62afd8b250f8c171e4d3a474ae1b0633903d0";
            }
            Token = token;
        }
    }

    /// 
    internal class GetDailyParams
    {
        /// 
        public string Code { get; set; } = string.Empty;

        /// 
        public string TradeDate { get; set; } = string.Empty;

        /// 
        public string StartDate { get; set; } = string.Empty;

        /// 
        public string EndDate { get; set; } = string.Empty;

        /// 
        public Dictionary<string, object> ToDictionary()
        {
            var dic = new Dictionary<string, object>();

            if( !string.IsNullOrEmpty( Code ) )
            {
                dic.Add( "ts_code", Code );
            }
            if( !string.IsNullOrEmpty( StartDate ) )
            {
                dic.Add( "start_date", StartDate );
            }
            if( !string.IsNullOrEmpty( EndDate ) )
            {
                dic.Add( "end_date", EndDate );
            }
            if( !string.IsNullOrEmpty( TradeDate ) )
            {
                dic.Add( "trade_date", TradeDate );
            }

            return dic;
        }

        /// 
        public GetDailyParams() {}

        /// 
        public GetDailyParams( IEnumerable<string> tsCodes )
        {
            Code = string.Join( ",", tsCodes );
        }
    }
}