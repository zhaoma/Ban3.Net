//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-29
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Response;

/// 
public class SohuResponse
{
    /// 
    public static IEnumerable<IStockNotion> ResultToNotions( IInternetResponse callback, NotionIs notionIs )
    {
        Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );

        var result = callback.Response.StringContent
                             .Substr( @"PEAK_ODIA(['pllist',", "])</script>" )
                             .SplitFix( "[", "]" )
                             .Select( item => item.Split( ',' ) )
                             .Select( entry => new StockNotion
                              {
                                  Id = entry[ 0 ].Replace( "'", "" ).ToInt(),
                                  Name = entry[ 1 ].Replace( "'", "" ),
                                  NotionIs = notionIs,
                                  Stocks = new List<Stock>()
                              } );

        return result;
    }

    public static IEnumerable<IStock> ResultToStocks( IInternetResponse callback )
    {
        return new List<IStock>();
    }
}