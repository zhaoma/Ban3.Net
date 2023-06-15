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

        public IActionResult Indicator(RenderView request)
        {
            var data = Signalert.Calculator.LoadIndicatorLine(request.Id, request.CycleEnum());
            return View(data);
        }

        public IActionResult Prices(string id, string cycle = "Daily")
        {
            return View();
        }
    }
}
