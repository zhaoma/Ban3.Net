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
    
    /// <summary>
    /// 买点（Config.）treemap
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ContentResult DotsTreemap(int id = 1)
    {
        var diagramName = id == 1
            ? $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Treemap.Buying"
            : $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Treemap.Selling";

        var diagram = diagramName.LoadDiagram();

        return Content(diagram.ObjToJson());
    }

    public ContentResult Bias(string id) 
    {
        var stock = Signalert.Collector.LoadStock(id);
        return Content(Signalert.Reportor.BiasDiagram(stock).ObjToJson());
    }
    public ContentResult Dmi(string id)
    {
        var stock = Signalert.Collector.LoadStock(id);
        return Content(Signalert.Reportor.DmiDiagram(stock).ObjToJson());
    }
    public ContentResult Kd(string id)
    {
        var stock = Signalert.Collector.LoadStock(id);
        return Content(Signalert.Reportor.KdDiagram(stock).ObjToJson());
    }
    public ContentResult Macd(string id)
    {
        var stock = Signalert.Collector.LoadStock(id);
        return Content(Signalert.Reportor.MacdDiagram(stock).ObjToJson());
    }

    public ContentResult Candlestick(string id, string cycle = "Daily")
    {
        cycle = cycle.ToUpper();

        var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();

        var diagram = new Stock { Code = id, }.LoadDiagram( cycleEnum).ObjToJson();

        return Content(diagram);
    }

    public ContentResult Sankey(int id)
    {
        var diagramName = id == 1
            ? $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Sankey.Buying"
            : $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Sankey.Selling";

        var diagram = diagramName.LoadDiagram();

        return Content(diagram.ObjToJson());
    }
}
