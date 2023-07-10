using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Productions.Casino.Contracts.Response;
using Ban3.Infrastructures.Indicators.Entries;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers;

public class PartsController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home");
    }

    /// <summary>
    /// dots of buying or selling main table
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public IActionResult Dots(RenderView request)
    {
        var dots = Signalert.GetDots(request);

        if (dots == null)
        {
            return Content("dots is empty");
        }

        request.Total = dots.Count;
        var result = new RenderViewResult<DotInfo>
        {
            Request = request,
            Counter = new Dictionary<string, int>(),
            ShowData = dots.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList()
        };
        result.Counter.Add("total", dots.Count());
        return string.IsNullOrEmpty(request.ViewName)
            ? View(result)
            : View(request.ViewName, result);
    }

    public IActionResult DotsKey(int id)
    {
        var dotsKey = Signalert.GetDotsKey(id == 1);
        return View(dotsKey);
    }

    public IActionResult Events(RenderView request)
    {
        var evs = Signalert.Collector.LoadOnesEvents(request.Id);
        return string.IsNullOrEmpty(request.ViewName)
            ? View(evs)
            : View(request.ViewName, evs);
    }

    public IActionResult Indicator(RenderView request)
    {
        var lineOfPoint = Signalert.GetLineOfPoint(request);
        return string.IsNullOrEmpty(request.ViewName)
            ? View(lineOfPoint)
            : View(request.ViewName, lineOfPoint);
    }

    public IActionResult List(RenderView request)
    {
        var listData = Signalert.GetListRecords();

        listData = listData?
        .Where(o =>
            (string.IsNullOrEmpty(request.StartsWith) || o.Code.StartsWithIn(request.StartsWith.Split(',')))
            &&
            (string.IsNullOrEmpty(request.EndsWith) || o.Code.EndsWith(request.EndsWith))
        )
        .Take(request.PageSize)
        .ToList();

        return string.IsNullOrEmpty(request.ViewName)
            ? View(listData)
            : View(request.ViewName, listData);
    }

    public IActionResult Prices(RenderView request)
    {
        var prices = Signalert.GetStockPrices(request);
        return string.IsNullOrEmpty(request.ViewName)
            ? View(prices)
            : View(request.ViewName, prices);
    }

    public IActionResult Sets(RenderView request)
    {
        var sets =Signalert.GetStockSets(request);
        return string.IsNullOrEmpty(request.ViewName)
            ? View(sets)
            : View(request.ViewName, sets);
    }

    public IActionResult Stock(RenderView request)
    {
        var stock = Signalert.Collector.LoadStock(request.Id);

        return string.IsNullOrEmpty(request.ViewName)
            ? View(stock)
            : View(request.ViewName, stock);
    }

    public IActionResult Stocks(RenderView request)
    {
        var stocks = Signalert.Collector.LoadAllCodes()
            .Where(o =>
                (string.IsNullOrEmpty(request.Id) || o.Code.Contains(request.Id))
                &&
                (string.IsNullOrEmpty(request.StartsWith) || o.Code.StartsWithIn(request.StartsWith.Split(',')))
                &&
                (string.IsNullOrEmpty(request.EndsWith) || o.Code.EndsWith(request.EndsWith))
            )
            .Take(50)
            .ToList();

        return string.IsNullOrEmpty(request.ViewName)
            ? View(stocks)
            : View(request.ViewName, stocks);
    }

    public IActionResult Features()
    {
        var features = Infrastructures.Indicators.Helper.Features;
        return View(features);
    }

    public IActionResult Codes(RenderView request)
    {
        var all = Signalert.Calculator.ScopedByRenderView(request);

        var result = all.Take(request.PageSize);

        return View(result);
    }
    
    public IActionResult OnesCodes(IFormCollection form)
    {
        var request = new RenderView
        {
            StartsWith = form["startsWith"],
            EndsWith = form["to"]
        };
        
        var includes = form["include"]+"";
        if (!string.IsNullOrEmpty(includes))
        {
            var includeKeys = new List<string>();
            foreach (var includeKey in includes.Split(','))
            {
                var cycles = form[$"{includeKey}.cycle"] + "";
                if (!string.IsNullOrEmpty(cycles))
                {
                    foreach (var s in cycles.Split(','))
                    {
                        includeKeys.Add($"{includeKey}.{s}");
                    }
                }
            }

            request.IncludeKeys = includeKeys.AggregateToString(",");
        }

        var excludes = form["exclude"] + "";
        if (!string.IsNullOrEmpty(excludes))
        {
            var excludeKeys = new List<string>();
            foreach (var excludeKey in excludes.Split(','))
            {
                var cycles = form[$"{excludeKey}.cycle"] + "";
                if (!string.IsNullOrEmpty(cycles))
                {
                    foreach (var s in cycles.Split(','))
                    {
                        excludeKeys.Add($"{excludeKey}.{s}");
                    }
                }
            }

            request.ExcludeKeys = excludeKeys.AggregateToString(",");
        }
        
        return RedirectToAction("Codes", request);
    }

    public IActionResult Summaries()
    {
        var data = Signalert.Analyzer.LoadSummary()
            .Select(o=>o.Value)
            .OrderBy(o=>o.RecordCount)
            .ToList();
        return View(data);
    }

    public IActionResult ProfileDetail(string id)
    {
        var codes = Signalert.Collector.ScopedCodes().Select(o=>o.Code).ToList();
        var data = Signalert.GetProfileDetails(codes, id);

        return View(data);
    }
}