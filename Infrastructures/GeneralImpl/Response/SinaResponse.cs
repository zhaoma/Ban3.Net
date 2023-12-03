//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using System.Linq;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Response;

/// 
public class SinaResponse
{
    /// 
    public static StockData<IStockEvent> ResultToEvents( IInternetResponse callback, IStock stock )
    {
        var result = callback.Response.StringContent.JsonToObj<TushareResponse.ApiResult>();

        var rows = result!
                  .Data!
                  .Items
                  .Select( row => new StockEvent
                   {
                       RecordDate = row[ 1 ],
                   } );

        return new StockData<IStockEvent>
        {
            Code = stock.Code,
            ListDate = stock.ListDate,
            Name = stock.Name,
            Symbol = stock.Symbol,
            Values = rows
        };
    }

    private List<StockEvent> HtmlToEvents( string html )
    {
        var result = new List<StockEvent>();

        var sb1 = html.Substr( "<!--分红 begin-->", "<!--分红 end-->" );

        if( !string.IsNullOrEmpty( sb1 ) )
        {
            var atrs = sb1.SplitTbody();

            foreach( var atr in atrs )
            {
                if( atr != null && atr.Count() > 4 )
                {
                    if( atr[ 1 ].ToDecimal() != 0 || atr[ 2 ].ToDecimal() != 0 || atr[ 3 ].ToDecimal() != 0 )
                    {
                        result.Add( new StockEvent
                        {
                            EventIs = EventIs.Sharing,
                            Subject = "分红",
                            RecordDate = atr[ 5 ],
                            Sbonus = atr[ 1 ].ToDecimal(),
                            Zbonus = atr[ 2 ].ToDecimal(),
                            Xmoney = atr[ 3 ].ToDecimal()
                        } );
                    }
                }
            }
        }

        var sb2 = html.Substr( "<!--配股 begin-->", "<!--配股 end-->" );
        if( !string.IsNullOrEmpty( sb2 ) )
        {
            var btrs = sb2.SplitTbody();

            foreach( var atr in btrs )
            {
                if( atr != null && atr.Count() > 4 )
                {
                    if( atr[ 1 ].ToDecimal() != 0 || atr[ 2 ].ToDecimal() != 0 || atr[ 3 ].ToDecimal() != 0 )
                    {
                        result.Add( new StockEvent
                        {
                            EventIs = EventIs.StockBonus,
                            Subject = "配股",
                            RecordDate = atr[ 4 ],
                            Pbonus = atr[ 1 ].ToDecimal(),
                            Pprice = atr[ 2 ].ToDecimal(),
                            Pcapital = atr[ 3 ].ToDecimal()
                        } );
                    }
                }
            }
        }

        return result;
    }
}