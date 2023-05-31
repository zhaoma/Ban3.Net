using System.Diagnostics;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Stocks(string id)
        {
            var stock = Signalert.Collector.LoadAllCodes()
                .FindLast(o => o.Code.ToUpper() == id.ToUpper());
            return View(stock);
        }
    }
}