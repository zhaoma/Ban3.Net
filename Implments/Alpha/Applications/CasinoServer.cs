//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Entries.CasinoServer;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components.Services;
using Ban3.Infrastructures.Contracts.Applications;
using Ban3.Infrastructures.Contracts.Components;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Ban3.Sites.ViaSina;
using Ban3.Sites.ViaTushare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 股市服务
/// </summary>
public class CasinoServer : ICasinoServer
{
    private readonly ICacheServer _cacheServer;
    private readonly IChartServer _chartServer;
    private readonly IDatabaseServer _databaseServer;
    private readonly IHttpServer _httpServer;
    private readonly ILoggerServer _logger;
    private readonly IMailServer _mailServer;
    private readonly IMessageServer _messageServer;

    public CasinoServer(
        ICacheServer cacheServer,
        IChartServer chartServer,
        IDatabaseServer databaseServer,
        IHttpServer httpServer,
        ILoggerServer logger,
        IMailServer mailServer,
        IMessageServer messageServer)
    {
        _cacheServer = cacheServer;
        _chartServer = chartServer;
        _databaseServer = databaseServer;
        _httpServer = httpServer;
        _logger = logger;
        _mailServer = mailServer;
        _messageServer = messageServer;
    }

    public Task<bool> PrepareAsync(bool withEvents)
    {
        var codes = new List<Stock>();

        try
        {
            var codesResponse = new Sites.ViaTushare.Request.GetStockBasic().GetResult();
            codes = codesResponse.Data.ObjToJson().JsonToObj<List<Stock>>()!;
            _databaseServer.SaveList<Stock>(codes);
        }
        catch (Exception ex) { _logger.Error(ex); }

        if (withEvents && codes.Any())
        {
            foreach (var c in codes)
            {
                try
                {
                    var a = new Sites.ViaSina.Request.DownloadEvents(c.Code).GetResult();
                    var b = new Sites.ViaSina.Request.DownloadLifts(c.Code).GetResult();

                    var all = a.Data.ObjToJson().JsonToObj<List<Bonus>>()
                         .Union(b.Data.ObjToJson().JsonToObj<List<Bonus>>())
                         .ToList();

                    _databaseServer.SaveList<Bonus>(all, () => c.Code);
                    (3, 7).RandomDelay();
                }
                catch (Exception ex) { _logger.Error(ex); }
            }
        }

        return Task.FromResult(true);
    }

    public List<IStock> LoadTargets()
        => _databaseServer.LoadList<IStock>(typeof(Stock));

    private List<Reinstate> CalculateSeeds(List<Price> prices, List<Bonus> events)
    {
        var result = new List<Reinstate>();
        try
        {
            if (events.Any())
            {
                foreach (var e in events)
                {
                    var price = prices.Last(o => o.MarkTime < e.MarkTime);
                    {
                        var close = (decimal)price.Close;

                        var thisSeed =
                            Math.Round(
                                close * (1 + (Math.Round(e.Sbonus, 0) + Math.Round(e.Zbonus, 0)) / 10M +
                                         Math.Round(e.Pbonus, 0) / 10M) / (close - e.Xmoney / 10M +
                                                                           Math.Round(e.Pbonus, 0) / 10M *
                                                                           Math.Round(e.Pprice, 2)), 4);

                        result.Add(new Reinstate { MarkTime = e.MarkTime, Factor = thisSeed });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return result;
    }

    public Task<bool> CollectPrices(IStock stock)
    {
        var getDailyParams = new Sites.ViaTushare.Request.GetDailyParams(new List<string> { stock.Code })
        {
            StartDate = DateTime.Now.AddYears(-10).ToYmd(),
            EndDate = DateTime.Now.AddDays(1).ToYmd()
        };

        var pricesResult = new Sites.ViaTushare.Request.GetStockPrice(getDailyParams).GetResult();

        var prices = pricesResult.Data.ObjToJson().JsonToObj<List<Price>>();

        _databaseServer.SaveList<Price>(prices, () => stock.Code);

        var factors = CalculateSeeds(prices, _databaseServer.LoadList<Bonus>(typeof(Bonus), () => stock.Code));

        _databaseServer.SaveList<Reinstate>(factors, () => stock.Code);

        var dailyPrices = prices.Select(p => ReinstateOnePrice(factors, p)).ToList();

        _databaseServer.SaveList<Price>(dailyPrices, () => $"{stock.Code}.{CycleIs.Daily}");

        return Task.FromResult(true);
    }

    private Price ReinstateOnePrice(List<Reinstate>? seeds, Price price)
    {
        var newPrice = new Price
        {
            Code = price.Code,
            MarkTime = price.MarkTime,
            Change = price.Change,
            ChangePercent = price.ChangePercent,
            Volumn = price.Volumn,
            Amount = price.Amount,

            Open = price.Open,
            High = price.High,
            Low = price.Low,
            Close = price.Close,
            PreClose = price.PreClose
        };

        try
        {
            if (seeds != null && seeds.Any())
            {
                foreach (var s in seeds)
                {
                    if (s.MarkTime.Subtract(price.MarkTime).TotalDays > 0)
                    {
                        newPrice.Open = Math.Round(price.Open / s.Factor, 2);
                        newPrice.High = Math.Round(price.High / s.Factor, 2);
                        newPrice.Low = Math.Round(price.Low / s.Factor, 2);
                        newPrice.Close = Math.Round(price.Close / s.Factor, 2);
                        newPrice.PreClose = Math.Round(price.PreClose / s.Factor, 2);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return newPrice;
    }


    public List<IPrice> LoadPrices(IStock stock, CycleIs? cycle)
    {
        var key = cycle != null ? stock.Code : $"{stock.Code}.{cycle}";
        return _databaseServer.LoadList<IPrice>(typeof(Price), () => key);
    }

    public Task<IResult> Calculate(IStock stock)
    {
        var dailyPrices = _databaseServer.LoadList<Price>(typeof(Price), () => $"{stock.Code}.{CycleIs.Daily}");

        if (dailyPrices == null || !dailyPrices.Any())
        {
            _logger.Error(new ArgumentNullException($"{stock.Code} prices is empty now,Skip."));
            return null;
        }

        var result = new Result
        {
            Stock = stock,
            Suggest = SuggestIs.Skip,
            Remarks = new IndicatorParameter().GenerateRemarks(dailyPrices)
        };

        _databaseServer.Create<Result>(result, (_) => stock.Code);

        return Task.FromResult((IResult)result);
    }

    public IResult LoadResult(IStock stock)
        => _databaseServer.Load<Result>(stock.Code);

    public Task<bool> GenerateSummary()
    {
        try
        {
            var summary = new Summary { MarkTime = DateTime.Now, Results = new List<IResult>() };

            var stocks = LoadTargets();

            foreach (var stock in stocks)
            {
                var r = LoadResult(stock);
                summary.Results.Add(new Result
                {
                    Stock = r.Stock,
                    Suggest = r.Suggest,
                    Notices = r.Notices,
                });
            }

            _databaseServer.Create<Summary>(summary, (_) => "all");

            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return Task.FromResult(false);
    }

    public ISummary LoadSummary()
        => _databaseServer.Load<Summary>("all");
}
