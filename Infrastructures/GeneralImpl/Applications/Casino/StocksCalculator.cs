//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-26
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;
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
        Action<IStockData<IStockSeed>>? action=null
    )
    {
        var prices = await TryLoadOriginalPrices(stock);
        var events = await _stockEventsCollector.TryLoad(stock);

        var seeds = new StockData<IStockSeed>(stock);
        var seedValues = new List<StockSeed>();

        foreach (var e in events.Values)
        {
            var price = prices.Values.Last(o => o.RecordDate.ToInt() < e.RecordDate.ToInt());
            if(price!=null)
            {
                var thisSeed =
                    Math.Round(
                      price.Close * (1 + (Math.Round(e.Sbonus, 0) + Math.Round(e.Zbonus, 0)) / 10M +
                                 Math.Round(e.Pbonus, 0) / 10M) / (price.Close - e.Xmoney / 10M +
                                                                   Math.Round(e.Pbonus, 0) / 10M *
                                                                   Math.Round(e.Pprice, 2)), 4);
                seedValues.Add(new StockSeed { Factor = thisSeed, RecordDate = e.RecordDate });
            }
        }

        seeds.Values = seedValues;

        if (action == null)
        {
            return await _storagesHelper.TrySave(seeds, stock.Code);
        }

        action(seeds);

        return await Task.FromResult(true);
    }

    /// 
    public async Task<IStockData<IStockSeed>> TryLoadSeeds(IStock stock)
        => await _storagesHelper.TryLoad<IStockData<IStockSeed>>(stock.Code);

    /// 
    public async Task<IStockData<IStockPrice>> TryLoadOriginalPrices(IStock stock)
        => await _storagesHelper.TryLoad<IStockData<IStockPrice>>(stock.Code);

    /// 
    public async Task<bool> TryRehabilitatePrices(
        IStock stock,
        Action<IStockData<IStockPrice>>? action = null
    )
    {
        var prices = await TryLoadOriginalPrices(stock);
        var seeds = await TryLoadSeeds(stock);

        var rehabilitatePrices = new StockData<IStockPrice>(stock);

        rehabilitatePrices.Values = prices.Values.Select(price =>
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
            foreach (var s in seeds.Values.Where(o => o.RecordDate.ToInt() > newPrice.RecordDate.ToInt()))
            {
                newPrice.Open = Math.Round(price.Open / s.Factor, 2);
                newPrice.High = Math.Round(price.High / s.Factor, 2);
                newPrice.Low = Math.Round(price.Low / s.Factor, 2);
                newPrice.Close = Math.Round(price.Close / s.Factor, 2);
                newPrice.PreClose = Math.Round(price.PreClose / s.Factor, 2);
            }
            return newPrice;
        });

        if (action == null)
        {
            return await _storagesHelper.TrySave(rehabilitatePrices, $"{stock.Code}.{AnalysisCycle.Daily}");
        }

        action(rehabilitatePrices);

        return await Task.FromResult(true);
    }

    /// 
    public async Task<bool> TryConvertCycle(
        IStock stock,
        Action<IStockData<IStockPrice>, IStockData<IStockPrice>>? action
    )
    {
        var dailyPrices = await TryLoadRehabilitatedPrices(stock, AnalysisCycle.Daily);

        var weekly = new List<StockPrice>();
        var monthly = new List<StockPrice>();
        try
        {
            if (dailyPrices != null && dailyPrices.Values.Any())
            {
                foreach (var price in dailyPrices.Values)
                {

                    AppendLatest(weekly, price, AnalysisCycle.Weekly);
                    AppendLatest(monthly, price, AnalysisCycle.Monthly);
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        var weeklyPrices = new StockData<IStockPrice>(stock) { Values = weekly };
        var monthlyPrices = new StockData<IStockPrice>(stock) { Values = monthly };

        if (action == null)
        {
            return await _storagesHelper.TrySave(weeklyPrices, $"{stock.Code}.{AnalysisCycle.Weekly}")
                && await _storagesHelper.TrySave(monthlyPrices, $"{stock.Code}.{AnalysisCycle.Monthly}");
        }

        action(weeklyPrices, monthlyPrices);

        return await Task.FromResult(true);
    }

    void AppendLatest(
        List<StockPrice> prices,
        IStockPrice addPrice,
        AnalysisCycle cycle)
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

        if (!prices.Any())
        {
            prices.Add(price);
        }
        else
        {
            var lastRecord = prices.Last();

            var exists =End( lastRecord.RecordDate.ToDateTimeEx(),cycle).ToYmd();
            var add =End( price.RecordDate.ToDateTimeEx(),cycle).ToYmd();
            if (exists.ToInt().Equals(add.ToInt()))
            {
                lastRecord.Close = price.Close;
                lastRecord.High = Math.Max(lastRecord.High, price.High);
                lastRecord.Low = Math.Min(lastRecord.Low, price.Low);
                lastRecord.Vol += price.Vol;
                lastRecord.Amount += price.Amount;
            }
            else
            {
                prices.Add(price);
            }
        }
    }

    ///
    DateTime End(DateTime begin, AnalysisCycle targetCycle)
    {
        return targetCycle == AnalysisCycle.Weekly
            ? begin.FindWeekEnd()
            : begin.FindMonthEnd();
    }

    /// 
    public async Task<IStockData<IStockPrice>> TryLoadRehabilitatedPrices(IStock stock, AnalysisCycle cycle)
        => await _storagesHelper.TryLoad<IStockData<IStockPrice>>($"{stock.Code}.{cycle}");

    /// 
    public async Task<bool> TryGenerateIndicators(
        IInput input,
        Action<IOutput>? output
    )
    {
        if (prices == null || !prices.Any())
        {
            Logger.Error("Prices is empty now,Skip.");
            return null;
        }

        var line = new LineOfPoint
        {
            EndPoints = prices
                .Select(o => new PointOfTime
                {
                    TradeDate = o.TradeDate,
                    Close = o.Close!.Value,
                    Amount = new Outputs.Values.AMOUNT
                    {
                        TradeDate = o.TradeDate,
                        RefAmounts = new List<LineWithValue>()
                    },
                    Bias = new Outputs.Values.BIAS { TradeDate = o.TradeDate },
                    Cci = new Outputs.Values.CCI
                    {
                        TradeDate = o.TradeDate,
                        RefTYP = Math.Round((o.High!.Value + o.Low!.Value + o.Close.Value) / 3, 3)
                    },
                    Dmi = new Outputs.Values.DMI
                    {
                        TradeDate = o.TradeDate,
                        RefADX = 0D,
                        RefADXR = 0D,
                        RefPDI = 0D,
                        RefMDI = 0D
                    },
                    Ene = new Outputs.Values.ENE { TradeDate = o.TradeDate },
                    Kd = new Outputs.Values.KD
                    {
                        TradeDate = o.TradeDate,
                        RefLLV = o.Low,
                        RefHHV = o.High
                    },
                    Ma = new Outputs.Values.MA { TradeDate = o.TradeDate, RefPrices = new List<LineWithValue>() },
                    Macd = new Outputs.Values.MACD { TradeDate = o.TradeDate }
                })
                .ToList()
        };

        var amount = new AMOUNT();
        var bias = new BIAS();
        var cci = new CCI();
        var dmi = new DMI();
        var ene = new ENE();
        var kd = new KD();
        var ma = new MA();
        var macd = new MACD();

        var middles = prices.Select(o =>
            new[]
            {
                o.High!.Value,
                o.Low!.Value,
                o.Close!.Value,
                0,
                0,
                Math.Abs(o.High.Value - o.Low.Value)
            }).ToList();

        var emaShortYest = 0D;
        var emaLongYest = 0D;
        var deaYest = 0D;

        for (var i = 0; i < prices.Count; i++)
        {
            #region AMOUNT

            try
            {
                foreach (var detail in amount.Details!)
                {
                    if (i >= detail.Days - 1)
                    {
                        if (line.EndPoints[i].Amount!.RefAmounts.All(o => o.Days != detail.Days))
                        {
                            line.EndPoints[i].Amount!.RefAmounts.Add(
                                new LineWithValue
                                {
                                    Ref = DescRangeAmountAverage(prices, i, detail.Days),
                                    Days = detail.Days
                                });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region BIAS

            if (i >= bias.N - 1)
            {
                var biasMA = DescRangeCloseAverage(prices, i, bias.N);

                if (biasMA != 0)
                {
                    line.EndPoints[i].Bias!.RefBIAS =
                        Math.Round((prices[i].Close!.Value - biasMA) / biasMA * 100D, 3);
                }
            }

            if (i >= bias.N + bias.M - 2)
            {
                var biasSum = 0D;
                for (int j = 0; j < bias.M; j++)
                {
                    if (line.EndPoints[i - j].Bias!.RefBIAS != null)
                    {
                        biasSum += line.EndPoints[i - j].Bias!.RefBIAS!.Value;
                    }
                }

                line.EndPoints[i].Bias!.RefBIASMA = Math.Round(biasSum / bias.M, 3);
            }

            #endregion

            #region CCI

            if (i >= cci.N - 1)
            {
                var rr = new List<double>();
                for (int r = i; r > i - cci.N; r--)
                {
                    rr.Add(line.EndPoints[r].Cci!.RefTYP);
                }

                line.EndPoints[i].Cci!.RefCCI = AVEDEV(line.EndPoints[i].Cci!.RefTYP, rr);
            }

            #endregion

            #region DMI

            try
            {
                if (i > 0)
                {
                    line.EndPoints[i].Dmi!.RefHD = middles[i][0] - middles[i - 1][0];
                    line.EndPoints[i].Dmi!.RefLD = middles[i - 1][1] - middles[i][1];

                    middles[i][3] =
                        line.EndPoints[i].Dmi!.RefHD!.Value > 0 && line.EndPoints[i].Dmi!.RefHD!.Value >
                        line.EndPoints[i].Dmi!.RefLD!.Value
                            ? line.EndPoints[i].Dmi!.RefHD!.Value
                            : 0D;
                    middles[i][4] =
                        line.EndPoints[i].Dmi!.RefLD!.Value > 0 && line.EndPoints[i].Dmi!.RefLD!.Value >
                        line.EndPoints[i].Dmi!.RefHD!.Value
                            ? line.EndPoints[i].Dmi!.RefLD!.Value
                            : 0D;

                    middles[i][5] = Math.Max(middles[i][5], Math.Abs(middles[i][0] - middles[i - 1][2]));
                    middles[i][5] = Math.Max(middles[i][5], Math.Abs(middles[i][1] - middles[i - 1][2]));

                    var dmp = 0D;
                    var dmm = 0D;
                    var mtr = 0D;
                    for (int index = 0; index < dmi.N; index++)
                    {
                        if (index <= i)
                        {
                            var current = Math.Max(0, i - index);

                            mtr += middles[current][5];
                            dmp += middles[current][3];
                            dmm += middles[current][4];
                        }
                    }

                    line.EndPoints[i].Dmi!.RefMTR = mtr;
                    line.EndPoints[i].Dmi!.RefDMP = dmp;
                    line.EndPoints[i].Dmi!.RefDMM = dmm;

                    if (mtr != 0)
                    {
                        line.EndPoints[i].Dmi!.RefPDI = dmp * 100 / mtr;
                        line.EndPoints[i].Dmi!.RefMDI = dmm * 100 / mtr;
                    }
                }
                else
                {
                    line.EndPoints[i].Dmi!.RefHD = 0D; // prices[i].Close;
                    line.EndPoints[i].Dmi!.RefLD = 0D; // -prices[i].CurrentOpenEx;
                    line.EndPoints[i].Dmi!.RefMTR = middles[i][5];
                }

                if (i >= dmi.M - 1)
                {
                    var adx = 0D;
                    for (int r = i; r > i - dmi.M; r--)
                    {
                        adx += line.EndPoints[r].Dmi!.RefPDI + line.EndPoints[r].Dmi!.RefMDI == 0D
                            ? 0D
                            : Math.Abs(line.EndPoints[r].Dmi!.RefMDI!.Value -
                                       line.EndPoints[r].Dmi!.RefPDI!.Value) /
                              (line.EndPoints[r].Dmi!.RefPDI!.Value +
                               line.EndPoints[r].Dmi!.RefMDI!.Value) *
                              100D;
                    }

                    line.EndPoints[i].Dmi!.RefADX = adx / dmi.M;
                }

                if (i >= 2 * dmi.M - 1)
                {
                    line.EndPoints[i].Dmi!.RefADXR = (line.EndPoints[i].Dmi!.RefADX!.Value +
                                                      line.EndPoints[i - dmi.M].Dmi!.RefADX!.Value) / 2;
                }

                line.EndPoints[i].Dmi!.RefADX = Math.Round(line.EndPoints[i].Dmi!.RefADX!.Value, 3);
                line.EndPoints[i].Dmi!.RefADXR = Math.Round(line.EndPoints[i].Dmi!.RefADXR!.Value, 3);
                line.EndPoints[i].Dmi!.RefHD = Math.Round(line.EndPoints[i].Dmi!.RefHD!.Value, 3);
                line.EndPoints[i].Dmi!.RefLD = Math.Round(line.EndPoints[i].Dmi!.RefLD!.Value, 3);
                line.EndPoints[i].Dmi!.RefMDI = Math.Round(line.EndPoints[i].Dmi!.RefMDI!.Value, 3);
                line.EndPoints[i].Dmi!.RefPDI = Math.Round(line.EndPoints[i].Dmi!.RefPDI!.Value, 3);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region ENE

            if (i >= ene.N - 1)
            {
                var eneMa = DescRangeCloseAverage(prices, i, ene.N);

                line.EndPoints[i].Ene!.RefUPPER = Math.Round((1 + ene.M1 / 100D) * eneMa, 2);
                line.EndPoints[i].Ene!.RefLOWER = Math.Round((1 - ene.M2 / 100D) * eneMa, 2);
                line.EndPoints[i].Ene!.RefENE =
                    Math.Round((line.EndPoints[i].Ene!.RefUPPER!.Value + line.EndPoints[i].Ene!.RefLOWER!.Value) / 2,
                        2);
            }

            #endregion

            #region KD

            try
            {
                line.EndPoints[i].Kd!.RefLLV = LLV(prices, i, kd.N);
                line.EndPoints[i].Kd!.RefHHV = HHV(prices, i, kd.N);

                if (line.EndPoints[i].Kd!.RefHHV - line.EndPoints[i].Kd!.RefLLV != 0)
                {
                    line.EndPoints[i].Kd!.RefDailyPSV = Math.Round(
                        (prices[i].Close!.Value - line.EndPoints[i].Kd!.RefLLV!.Value) * 100D /
                        (line.EndPoints[i].Kd!.RefHHV!.Value - line.EndPoints[i].Kd!.RefLLV!.Value), 3);
                }
                else
                {
                    line.EndPoints[i].Kd!.RefDailyPSV = 0;
                }

                if (i > 0)
                {
                    line.EndPoints[i].Kd!.RefPSV = EMA(
                        line.EndPoints[i].Kd!.RefDailyPSV!.Value,
                        line.EndPoints[i - 1].Kd!.RefPSV!.Value,
                        kd.M);

                    line.EndPoints[i].Kd!.RefK = EMA(
                        line.EndPoints[i].Kd!.RefPSV!.Value,
                        line.EndPoints[i - 1].Kd!.RefK!.Value,
                        kd.M);
                }
                else
                {
                    line.EndPoints[i].Kd!.RefPSV = line.EndPoints[i].Kd!.RefDailyPSV;
                    line.EndPoints[i].Kd!.RefK = line.EndPoints[i].Kd!.RefDailyPSV;
                }

                if (i >= kd.M - 1)
                {
                    var d = 0D;
                    for (int r = 0; r < kd.M; r++)
                    {
                        d += line.EndPoints[i - r].Kd!.RefK!.Value;
                    }

                    line.EndPoints[i].Kd!.RefD = Math.Round(d / kd.M, 3);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region MA

            try
            {
                if (ma.Details != null)
                {
                    foreach (var detail in ma.Details)
                    {
                        if (i >= detail.Days - 1)
                        {
                            var maMa = DescRangeCloseAverage(prices, i, detail.Days);

                            if (line.EndPoints[i].Ma!.RefPrices.All(o => o.Days != detail.Days))
                            {
                                line.EndPoints[i].Ma!.RefPrices.Add(
                                    new LineWithValue
                                    {
                                        Ref = Math.Round(maMa, 2),
                                        Days = detail.Days
                                    });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region MACD

            try
            {
                #region Calc

                if (i == 0)
                {
                    line.EndPoints[i].Macd = new Outputs.Values.MACD
                    {
                        TradeDate = prices[i].TradeDate,
                        RefEMAShort = prices[i].Close!.Value,
                        RefEMALong = prices[i].Close!.Value
                    };
                }
                else
                {
                    line.EndPoints[i].Macd = new Outputs.Values.MACD
                    {
                        TradeDate = prices[i].TradeDate,
                        RefEMAShort = EMA(prices[i].Close!.Value, emaShortYest, macd.SHORT),
                        RefEMALong = EMA(prices[i].Close!.Value, emaLongYest, macd.LONG)
                    };

                    line.EndPoints[i].Macd!.RefDIF =
                        Math.Round(line.EndPoints[i].Macd!.RefEMAShort - line.EndPoints[i].Macd!.RefEMALong, 3);
                    line.EndPoints[i].Macd!.RefDEA =
                        Math.Round(
                            deaYest * (macd.MID - 1) / (macd.MID + 1) +
                            line.EndPoints[i].Macd!.RefDIF * 2 / (macd.MID + 1), 3);
                    line.EndPoints[i].Macd!.RefMACD =
                        Math.Round(2 * (line.EndPoints[i].Macd!.RefDIF - line.EndPoints[i].Macd!.RefDEA), 3);
                }

                emaShortYest = line.EndPoints[i].Macd!.RefEMAShort;
                emaLongYest = line.EndPoints[i].Macd!.RefEMALong;
                deaYest = line.EndPoints[i].Macd!.RefDEA;

                #endregion
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion
        }

        return await Task.FromResult(true);
    }

    /// 
    public async Task<IOutput> TryLoadIndicators(IStock stock)
        => await _storagesHelper.TryLoad<IOutput>(stock.Code);
}