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
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Applications;

public class CasinoServer:ICasinoServer
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

        if (dailyPrices != null && dailyPrices.Any())
        {
            var weekly = new List<Price>();

            var monthly = new List<Price>();

            for (int i = 1; i <= dailyPrices.Count; i++)
            {
                AppendLatest(weekly,dailyPrices[i - 1], CycleIs.Weekly);

                AppendLatest(monthly,dailyPrices[i - 1], CycleIs.Monthly);
            }

            _databaseServer.SaveList<Price>(weekly, () => $"{stock.Code}.{CycleIs.Weekly}");

            _databaseServer.SaveList<Price>(monthly, () => $"{stock.Code}.{CycleIs.Monthly}");
        }

        return Task.FromResult( true );
    }

    private Price ReinstateOnePrice(List<Reinstate>? seeds, Price price)
    {
        var newPrice = new Price
        {
            Code = price.Code,
            TradeDate = price.TradeDate,
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
                    if (s.MarkTime.Subtract(price.TradeDate.ToDateTimeEx()).TotalDays > 0)
                    {
                        newPrice.Open =Math.Round(price.Open / s.Factor, 2);
                        newPrice.High =Math.Round(price.High / s.Factor, 2);
                        newPrice.Low = Math.Round(price.Low / s.Factor, 2);
                        newPrice.Close = Math.Round(price.Close / s.Factor, 2);
                        newPrice.PreClose =Math.Round(price.PreClose / s.Factor, 2);
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

    private void AppendLatest(List<Price> prices, Price addPrice, CycleIs cycle)
    {
        Price price = new Price
        {
            Code = addPrice.Code,
            MarkTime = addPrice.MarkTime,
            Open = addPrice.Open,
            High = addPrice.High,
            Low = addPrice.Low,
            Close = addPrice.Close,
            PreClose = addPrice.PreClose,
            Volumn = addPrice.Volumn,
            Amount = addPrice.Amount
        };
        if (!prices.Any())
        {
            prices.Add(price);
            return;
        }

        Price price2 = prices.Last();
        string strValue = End(price2.MarkTime, cycle).ToYmd();
        string strValue2 = End(price.MarkTime, cycle).ToYmd();
        if (strValue.ToInt().Equals(strValue2.ToInt()))
        {
            price2.Close = price.Close;
            price2.High = Math.Max(price2.High, price.High);
            price2.Low = Math.Min(price2.Low, price.Low);
            price2.Volumn += price.Volumn;
            price2.Amount += price.Amount;
            price2.Change = price2.Close - price2.PreClose;
            price2.ChangePercent = ((price2.PreClose != 0.0M) ? (Math.Round((price2.Close - price2.PreClose) / price2.PreClose * 100.0M, 2)) : 0M);
        }
        else
        {
            prices.Add(price);
        }
    }

    private DateTime End(DateTime begin, CycleIs stockCycle)
    {
        if (stockCycle != CycleIs.Weekly)
        {
            return begin.FindMonthEnd();
        }

        return begin.FindWeekEnd();
    }

    public List<IPrice> LoadPrices(IStock stock,CycleIs? cycle)
    {
        var key = cycle != null ? stock.Code : $"{stock.Code}.{cycle}";
        return _databaseServer.LoadList<IPrice>(typeof(Price),() => key);
    }

    public Task<IResult>? Calculate(IStock stock)
    {
       var dailyPrices= _databaseServer.LoadList<Price>(typeof(Price), () => $"{stock.Code}.{CycleIs.Daily}");

        if (dailyPrices == null || !dailyPrices.Any())
        {
            _logger.Error(new ArgumentNullException($"{stock.Code} prices is empty now,Skip."));
            return null;
        }

        var result = new Result
        {
            Stock = stock,
            Suggest=SuggestIs.Skip
        };

        var weekly = new List<Price>();

        var monthly = new List<Price>();

        for (int i = 1; i <= dailyPrices.Count; i++)
        {
            AppendLatest(weekly, dailyPrices[i - 1], CycleIs.Weekly);

            AppendLatest(monthly, dailyPrices[i - 1], CycleIs.Monthly);

            result.Remarks.Add(
                new Remark
                {
                    DayPrice = dailyPrices[i - 1],
                    Suggest = SuggestIs.Skip,
                    Outputs = new Dictionary<CycleIs, IOutput> {
                        OneDay(),
                    }
                }) ;
        }

        return Task.FromResult((IResult)result);
    }

    private Output OneDay(List<Price> daily,int index)
    {
        return new Output { 
        Keys=new List<string>(),
        MA=
        };
    }

    /// <summary>
    /// RefMACD
    /// </summary>
    /// <param name="current"></param>
    /// <param name="yest"></param>
    /// <param name="days"></param>
    /// <param name="round"></param>
    /// <returns></returns>
    private decimal EMA(decimal current, decimal yest, int days, int round = 3)
    {
        return Math.Round((current * 2.0M + yest * (decimal)(days - 1)) / (decimal)(days + 1), round);
    }

    private decimal MA(List<Price> prices,Func<Price,decimal> selectValue, int current, int N)
    {
        decimal num = 0.0M;
        int num2 = 0;
        for (int i = 0; i < N; i++)
        {
            if (current > i)
            {
                num2++;
                num += selectValue(prices[Math.Max(0, current - i)]);
            }
        }

        return Math.Round(num / (decimal)num2, 0);
    }

    public IResult LoadResult(IStock stock)
    {

    }

    public Task<bool> GenerateSummary()
    {

    }

    public ISummary LoadSummary()
    {

    }
}
