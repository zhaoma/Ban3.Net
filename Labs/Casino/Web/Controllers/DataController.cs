using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ContentResult Treemap()
            => Content(Signalert.LoadCurrentTreemap(Config.DefaultFilter).ObjToJson());

        public ContentResult Candlestick(string id, string cycle = "Daily")
        {
            cycle = cycle.ToUpper();
            var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();
            var diagram = Signalert.LoadDiagramContent(new Stock { Code = id, }, cycleEnum);

            return Content(diagram);
        }
    }
}
