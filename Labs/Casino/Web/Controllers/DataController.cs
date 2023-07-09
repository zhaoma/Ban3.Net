using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers;

public class DataController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home");
    }

    public ContentResult FindAnything(string id)
    {
        var allCodes = Signalert.Collector.LoadAllCodes()
            .Where(o=>o.Code.Contains(id.ToUpper()))
            .Take(50)
            .ToList();

        return Content(allCodes.ObjToJson());
    }
    
    public ContentResult DotsTreemap(int id = 1)
        => Content(Signalert.GetTreemapDiagram(id));

    public ContentResult Bias(string id)
        => Content(Signalert.GetBiasDiagram(id));

    public ContentResult Dmi(string id)
        => Content(Signalert.GetDmiDiagram(id));

    public ContentResult Kd(string id)
        => Content(Signalert.GetKdDiagram(id));
    
    public ContentResult Macd(string id)
        => Content(Signalert.GetMacdDiagram(id));

    public ContentResult Candlestick(string id, string cycle = "Daily")
        => Content(Signalert.GetCandlestickDiagram(id, cycle));

    public ContentResult Sankey(int id)
        => Content(Signalert.GetSankeyDiagram(id));
}
