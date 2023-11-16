// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Response;

/// 
public class TushareResponse
{
    /// 
    public static List<Stock> ResultToCodes( IInternetResponse callback )
    {
        var result = callback.Response.StringContent.JsonToObj<TushareResponse.ApiResult>();

        return result!
              .Data!
              .Items
              .Select( row => new Stock
               {
                   Code = row[ 0 ],
                   Symbol = row[ 1 ],
                   Name = row[ 2 ],
                   ListDate = row[ 3 ]
               } )
              .OrderBy( o => o.Code )
              .ToList();
    }

    /// 
    public static StockData<IStockPrice> ResultToPrices( IInternetResponse callback, IStock stock )
    {
        var result = callback.Response.StringContent.JsonToObj<TushareResponse.ApiResult>();

        var rows = result!
                  .Data!
                  .Items
                  .Select( row => new StockPrice
                   {
                       RecordDate = row[ 1 ],
                       Open = row[ 2 ].ToDecimal(),
                       High = row[ 3 ].ToDecimal(),
                       Low = row[ 4 ].ToDecimal(),
                       Close = row[ 5 ].ToDecimal(),
                       PreClose = row[ 6 ].ToDecimal(),
                       Vol = row[ 9 ].ToFloat(),
                       Amount = row[ 10 ].ToFloat()
                   } );

        return new StockData<IStockPrice>
        {
            Code = stock.Code,
            ListDate = stock.ListDate,
            Name = stock.Name,
            Symbol = stock.Symbol,
            Values = rows
        };
    }

    /// 
    internal class ApiResult
    {
        /// 
        [JsonProperty( "request_id" )]
        public string RequestId { get; set; } = string.Empty;

        /// 
        [JsonProperty( "code" )]
        public int Code { get; set; }

        /// 
        [JsonProperty( "msg" )]
        public string Message { get; set; } = string.Empty;

        /// 
        [JsonProperty( "data" )]
        public ApiResponseData? Data { get; set; }
    }

    /// 
    internal class ApiResponseData
    {
        /// <summary>
        /// 索取的字段
        /// </summary>
        [JsonProperty( "fields" )]
        public List<string> Fields { get; set; } = new();

        /// <summary>
        /// 索取结果数组的集合
        /// </summary>
        [JsonProperty( "items" )]
        public List<List<string>> Items { get; set; } = new();
    }
}