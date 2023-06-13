using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ban3.Labs.Casino.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string id)
    {
        return string.IsNullOrEmpty(id)
            ? View()
            : View(id);
    }

    public IActionResult Stocks(string id)
    {
        var allCodes = Signalert.Collector.LoadAllCodes();
        var stock = allCodes.FindLast(o => o.Code.ToUpper() == id.ToUpper());

        if (stock == null)
            return RedirectToAction("Index");

        return View(stock);
    }

    public ContentResult Diagram(string id, string cycle = "Daily")
    {
        cycle = cycle.ToUpper();
        var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();
        var diagram = Signalert.LoadDiagramContent(new Stock { Code = id, }, cycleEnum);

        return Content(diagram);
    }

    public IActionResult Indicator(string id, string cycle = "Daily")
    {
        cycle = cycle.ToUpper();
        var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();
        var data= Signalert.Calculator.LoadIndicatorLine(id, cycleEnum);
        return View(data);
    }

    public IActionResult Sets(string id, string cycle = "Daily")
    {

    }
}