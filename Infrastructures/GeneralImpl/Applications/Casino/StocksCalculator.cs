//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-26
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

public class StocksCalculator : OneImplement, IStocksCalculator
{
    private IStoragesHelper _storagesHelper;

    public StocksCalculator(
        IStoragesHelper storagesHelper)
    {
        _storagesHelper = storagesHelper;

    }

    /// 
    public async Task<bool> TryGenerateSeeds(
       IStockData<IStockEvent> stockEvents,
       Action<IStockData<IStockSeed>> action
    )
    {

    }


    /// 
    public async Task<IStockData<IStockSeed>> TryLoadSeeds(IStock stock)
    {

    }


    /// 
    public async Task<IStockData<IStockPrice>> TryLoadOriginalPrices(IStock stock)
        => await _storagesHelper.TryLoad<IStockData<IStockPrice>>(stock.Code);


    /// 
    public async Task<bool> TryAdjustPrices(
        IStockData<IStockPrice> sourcePrices,
        IStockData<IStockSeed> stockSeeds,
        Action<IStockData<IStockPrice>> action
    )
    {

    }


    /// 
    public async Task<bool> TryConvertCycle(
        IStockData<IStockPrice> dailyPrices,
        AnalysisCycle analysisCycle,
        Action<AnalysisCycle, IStockData<IStockPrice>> action
    );


    /// 
    public async Task<IStockData<IStockPrice>> TryLoadRehabilitatedPrices(IStock stock, AnalysisCycle cycle)
        => await _storagesHelper.TryLoad<IStockData<IStockPrice>>($"{stock.Code}.{cycle}");

    /// 
    public async Task<bool> TryGenerateIndicators(
        IInput input,
        Action<IOutput> output
    )
    {

    }

    /// 
    public async Task<IOutput> TryLoadIndicators(IStock stock)
    {

    }
}

