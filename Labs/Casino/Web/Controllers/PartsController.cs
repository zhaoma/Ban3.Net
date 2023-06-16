using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers
{
    public class PartsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
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
            var lineOfPoint = Signalert.Calculator.LoadIndicatorLine(request.Id, request.CycleEnum());
            return string.IsNullOrEmpty(request.ViewName)
                ? View(lineOfPoint)
                : View(request.ViewName, lineOfPoint);
        }

        public IActionResult List(RenderView request)
        {
            var listName = DateTime.Now.ToYmd();
            var listData = Signalert.Calculator.LoadList(listName)
                .Where(o =>
                    (string.IsNullOrEmpty(request.StartsWith) || o.Code.StartsWithIn(request.StartsWith.Split(',')))
                    &&
                    (string.IsNullOrEmpty(request.EndsWith) || o.Code.EndsWith(request.EndsWith))
                );

            return string.IsNullOrEmpty(request.ViewName)
                ? View(listData)
                : View(request.ViewName, listData);
        }

        public IActionResult Prices(RenderView request)
        {
            var prices = Signalert.Calculator.LoadReinstatedPrices(request.Id, request.CycleEnum());
            return string.IsNullOrEmpty(request.ViewName)
                ? View(prices)
                : View(request.ViewName, prices);
        }

        public IActionResult Sets(RenderView request)
        {
            var cycle = request.CycleEnum();
            var sets = cycle==StockAnalysisCycle.DAILY
                            ?Signalert.Calculator.LoadSets(request.Id)
                            :Signalert.Calculator.LoadIndicatorLine(request.Id, cycle).LineToSets();
            return string.IsNullOrEmpty(request.ViewName)
                ? View(sets)
                : View(request.ViewName, sets);
        }

        public IActionResult Stocks(RenderView request)
        {
            var stocks = Signalert.Collector.LoadAllCodes()
                .Where(o =>
                    (string.IsNullOrEmpty(request.StartsWith) || o.Code.StartsWithIn(request.StartsWith.Split(',')))
                    &&
                    (string.IsNullOrEmpty(request.EndsWith) || o.Code.EndsWith(request.EndsWith))
                );

            return string.IsNullOrEmpty(request.ViewName)
                ? View(stocks)
                : View(request.ViewName, stocks);
        }
    }
}
