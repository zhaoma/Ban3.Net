using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers
{
    public class PartsController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Indicator(string id, string cycle = "Daily")
        {
            cycle = cycle.ToUpper();
            var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();
            var data = Signalert.Calculator.LoadIndicatorLine(id, cycleEnum);
            return View(data);
        }
    }
}
