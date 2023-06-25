using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Productions.Casino.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers
{
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
            var dots = Signalert.Reportor.LoadDots(Config.DefaultFilter)
                .ExtendedDots(request);

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
            var dots = Signalert.Reportor.LoadDotsKey(Config.DefaultFilter, id == 1);
            return  View(dots);
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
            var listData = Signalert.Calculator.LoadList();

                listData=listData
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
    }
}
