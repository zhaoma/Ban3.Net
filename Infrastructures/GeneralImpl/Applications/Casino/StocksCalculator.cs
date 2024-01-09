//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-26
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using Amount = Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs.Amount;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

///
public class StocksCalculator : OneImplement, IStocksCalculator
{
    private IStoragesHelper _storagesHelper;
    private IStockEventsCollector _stockEventsCollector;

    ///
    public StocksCalculator(
        IStoragesHelper storagesHelper,
        IStockEventsCollector stockEventsCollector
    )
    {
        _storagesHelper = storagesHelper;
        _stockEventsCollector = stockEventsCollector;
    }

    /// 
    public async Task<bool> TryGenerateSeeds(
        IStock stock,
        Action<IStockData<IStockSeed>>? action = null
    )
    {
        var prices = await TryLoadOriginalPrices( stock );
        var events = await _stockEventsCollector.TryLoad( stock );

        var seeds = new StockData<IStockSeed>( stock );
        var seedValues = new List<StockSeed>();

        foreach( var e in events.Values )
        {
            var price = prices.Values.Last( o => o.RecordDate.ToInt() < e.RecordDate.ToInt() );
            if( price != null )
            {
                var thisSeed =
                    Math.Round(
                        price.Close * ( 1 + ( Math.Round( e.Sbonus, 0 ) + Math.Round( e.Zbonus, 0 ) ) / 10M +
                                        Math.Round( e.Pbonus, 0 ) / 10M ) / ( price.Close - e.Xmoney / 10M +
                                                                              Math.Round( e.Pbonus, 0 ) / 10M *
                                                                              Math.Round( e.Pprice, 2 ) ), 4 );
                seedValues.Add( new StockSeed { Factor = thisSeed, RecordDate = e.RecordDate } );
            }
        }

        seeds.Values = seedValues;

        if( action == null )
        {
            return await _storagesHelper.TrySave( seeds, stock.Code );
        }

        action( seeds );

        return await Task.FromResult( true );
    }

    /// 
    public async Task<IStockData<IStockSeed>> TryLoadSeeds( IStock stock )
        => await _storagesHelper.TryLoad<IStockData<IStockSeed>>( stock.Code );

    /// 
    public async Task<IStockData<IStockPrice>> TryLoadOriginalPrices( IStock stock )
        => await _storagesHelper.TryLoad<IStockData<IStockPrice>>( stock.Code );

    /// 
    public async Task<bool> TryRehabilitatePrices(
        IStock stock,
        Action<IStockData<IStockPrice>>? action = null
    )
    {
        var prices = await TryLoadOriginalPrices( stock );
        var seeds = await TryLoadSeeds( stock );

        var rehabilitatePrices = new StockData<IStockPrice>( stock );

        rehabilitatePrices.Values = prices.Values.Select( price =>
        {
            var newPrice = new StockPrice
            {
                RecordDate = price.RecordDate,
                Vol = price.Vol,
                Amount = price.Amount,
                Open = price.Open,
                High = price.High,
                Low = price.Low,
                Close = price.Close,
                PreClose = price.PreClose
            };
            foreach( var s in seeds.Values.Where( o => o.RecordDate.ToInt() > newPrice.RecordDate.ToInt() ) )
            {
                newPrice.Open = Math.Round( price.Open / s.Factor, 2 );
                newPrice.High = Math.Round( price.High / s.Factor, 2 );
                newPrice.Low = Math.Round( price.Low / s.Factor, 2 );
                newPrice.Close = Math.Round( price.Close / s.Factor, 2 );
                newPrice.PreClose = Math.Round( price.PreClose / s.Factor, 2 );
            }
            return newPrice;
        } );

        if( action == null )
        {
            return await _storagesHelper.TrySave( rehabilitatePrices, $"{stock.Code}.{AnalysisCycle.Daily}" );
        }

        action( rehabilitatePrices );

        return await Task.FromResult( true );
    }

    /// 
    public async Task<bool> TryConvertCycle(
        IStock stock,
        Action<IStockData<IStockPrice>, IStockData<IStockPrice>>? action
    )
    {
        var dailyPrices = await TryLoadRehabilitatedPrices( stock, AnalysisCycle.Daily );

        var weekly = new List<StockPrice>();
        var monthly = new List<StockPrice>();
        try
        {
            if( dailyPrices != null && dailyPrices.Values.Any() )
            {
                foreach( var price in dailyPrices.Values )
                {
                    AppendLatest( weekly, price, AnalysisCycle.Weekly );
                    AppendLatest( monthly, price, AnalysisCycle.Monthly );
                }
            }

            return true;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        var weeklyPrices = new StockData<IStockPrice>( stock ) { Values = weekly };
        var monthlyPrices = new StockData<IStockPrice>( stock ) { Values = monthly };

        if( action == null )
        {
            return await _storagesHelper.TrySave( weeklyPrices, $"{stock.Code}.{AnalysisCycle.Weekly}" )
                && await _storagesHelper.TrySave( monthlyPrices, $"{stock.Code}.{AnalysisCycle.Monthly}" );
        }

        action( weeklyPrices, monthlyPrices );

        return await Task.FromResult( true );
    }

    void AppendLatest(
        List<StockPrice> prices,
        IStockPrice addPrice,
        AnalysisCycle cycle )
    {
        var price = new StockPrice
        {
            RecordDate = addPrice.RecordDate,
            Open = addPrice.Open,
            High = addPrice.High,
            Low = addPrice.Low,
            Close = addPrice.Close,
            PreClose = addPrice.PreClose,
            Vol = addPrice.Vol,
            Amount = addPrice.Amount
        };

        if( !prices.Any() )
        {
            prices.Add( price );
        }
        else
        {
            var lastRecord = prices.Last();

            var exists = End( lastRecord.RecordDate.ToDateTimeEx(), cycle ).ToYmd();
            var add = End( price.RecordDate.ToDateTimeEx(), cycle ).ToYmd();
            if( exists.ToInt().Equals( add.ToInt() ) )
            {
                lastRecord.Close = price.Close;
                lastRecord.High = Math.Max( lastRecord.High, price.High );
                lastRecord.Low = Math.Min( lastRecord.Low, price.Low );
                lastRecord.Vol += price.Vol;
                lastRecord.Amount += price.Amount;
            }
            else
            {
                prices.Add( price );
            }
        }
    }

    ///
    DateTime End( DateTime begin, AnalysisCycle targetCycle )
    {
        return targetCycle == AnalysisCycle.Weekly
            ? begin.FindWeekEnd()
            : begin.FindMonthEnd();
    }

    /// 
    public async Task<IStockData<IStockPrice>> TryLoadRehabilitatedPrices( IStock stock, AnalysisCycle cycle )
        => await _storagesHelper.TryLoad<IStockData<IStockPrice>>( $"{stock.Code}.{cycle}" );

    /// 
    public async Task<bool> TryGenerateIndicators(
        IInput input,
        Action<IOutput>? action
    )
    {
        if( input.StockPrices == null || !input.StockPrices.Any() )
        {
            return await Task.FromResult( false );
        }

        var dic = new Dictionary<AnalysisCycle, IEnumerable<IComputedResult>>();

        foreach( var kv in input.StockPrices )
        {
            if( TryParseOneCycle( kv.Value.ToList(), Config.CurrentFormulas, out var computedResults ) )
            {
                dic.Add( kv.Key, computedResults );
            }
        }

        var output = new Output { Code = input.Stock.Code, ComputedResults = dic };

        if( action == null )
        {
            return await _storagesHelper.TrySave( output, $"{output.Code}" );
        }

        action( output );

        return await Task.FromResult( true );
    }

    private bool TryParseOneCycle(
        List<IStockPrice> prices,
        Formulas formulas,
        out List<ComputedResult> result )
    {
        result = new List<ComputedResult>();

        try
        {
            for( var i = 0; i < prices.Count; i++ )
            {
                foreach( var formula in formulas.Parameters )
                {
                    if( CalculateActions.TryGetValue( formula.IndicatorIs, out var action ) )
                    {
                        var r = result.Last( o => o.IndicatorIs == formula.IndicatorIs );
                        if( r == null )
                        {
                            r = new ComputedResult { IndicatorIs = formula.IndicatorIs };
                        }
                        action( formula, prices, i, r );
                    }
                }
            }

            return true;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return false;
    }

    public static readonly Dictionary<IndicatorIs, Action<IParameter, List<IStockPrice>, int, ComputedResult>>
        CalculateActions = new()
        {
            {
                IndicatorIs.AMOUNT, ( indicatorParameter, prices, index, result ) =>
                {
                    var amount = (Amount)indicatorParameter;
                    var calculated = new Entries.Casino.Indicators.Outputs.Amount
                    {
                        Lines = amount.Durations.Select( o => new Line<double> {} )
                    };

                    //result==null?

                    //foreach( var detail in amount.Durations )
                    //{
                    //    if( index >= detail - 1 )
                    //    {
                    //        if( line.EndPoints[ i ].Amount!.RefAmounts.All( o => o.Days != detail.Days ) )
                    //        {
                    //            line.EndPoints[ i ].Amount!.RefAmounts.Add(
                    //                new LineWithValue
                    //                {
                    //                    Ref = DescRangeAmountAverage( prices, i, detail.Days ),
                    //                    Days = detail.Days
                    //                } );
                    //        }
                    //    }
                    //}
                }
            },
            { IndicatorIs.BBI, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.BIAS, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.CCI, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.DMI, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.ENE, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.KD, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.LWR, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.MA, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.MACD, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.MTM, ( indicatorParameter, prices, index, result ) => {} },
            { IndicatorIs.RSI, ( indicatorParameter, prices, index, result ) => {} }
        };

    /// 
    public async Task<IOutput> TryLoadIndicators( IStock stock )
        => await _storagesHelper.TryLoad<IOutput>( stock.Code );
}