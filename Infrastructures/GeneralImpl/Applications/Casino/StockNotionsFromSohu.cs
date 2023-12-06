//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Response;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

public class StockNotionsFromSohu
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    ///
    public StockNotionsFromSohu(
        IInternetsHelper internetsHelper,
        IStoragesHelper storagesHelper )
    {
        _internetsHelper = internetsHelper;
        _storagesHelper = storagesHelper;
    }

    ///
    public async Task<bool> TryFetchNotions( Action<IEnumerable<IStockNotion>>? action )
    {
        var dic = new Dictionary<int, IStockNotion>();
        typeof( NotionIs ).EnumOptions()
                          .ForEach(
                               o =>
                               {
                                   var got = _internetsHelper
                                      .TryRequest(
                                           Request.SohuRequest.ResourceForNotions( o.Value ),
                                           callback =>
                                           {
                                               var data = SohuResponse.ResultToNotions( callback, (NotionIs)o.Value );
                                               dic.AddRange( data.Select( row => new KeyValuePair<int, IStockNotion>( row.Id, row ) ) );
                                           }
                                       );
                               } );

        foreach( var stockNotion in dic )
        {
            await _internetsHelper
               .TryRequest(
                    Request.SohuRequest.ResourceForNotionStocks( stockNotion.Key ),
                    callback =>
                    {
                        var one = new StockNotion
                        {
                            Id = stockNotion.Key,
                            Name = stockNotion.Value.Name
                        };
                        one.Stocks = SohuResponse.ResultToStocks( callback );
                        dic.AddOrReplace( stockNotion.Key, one );
                    }
                );
        }

        var notions = dic.Select( o => o.Value );
        if( action == null )
        {
            return await _storagesHelper.TrySave( notions, "all" );
        }

        action( notions );

        return await Task.FromResult( true );
    }

    ///
    public async Task<IEnumerable<IStockNotion>> TryLoad()
        => await _storagesHelper.TryLoad<IEnumerable<StockNotion>>( "all" );

    ///
    public async Task<IEnumerable<IStock>> TryLoad( IStockNotion stockNotion )
        => await _storagesHelper.TryLoad<IEnumerable<Stock>>( $"Notion.{stockNotion.Id}.Stocks" );

    ///
    public async Task<IEnumerable<IStockNotion>> TryLoad( IStock stock )
        => await _storagesHelper.TryLoad<IEnumerable<StockNotion>>( $"Stock.{stock.Code}.Notions" );
}