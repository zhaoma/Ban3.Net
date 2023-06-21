using Ban3.Infrastructures.Common.Extensions;
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

    public ContentResult CurrentTreemap()
        => Content(Signalert.LoadCurrentTreemap(Config.DefaultFilter).ObjToJson());

    public ContentResult PreviousTreemap()
        => Content(Signalert.LoadPreviousTreemap(Config.DefaultFilter).ObjToJson());

    /// <summary>
    /// 买点（Config.）treemap
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ContentResult DotsTreemap(int id = 1)
    {
        var dic = Signalert.Reportor.LoadDotsKey(Config.DefaultFilter, id == 1);
        var diagram = Signalert.Reportor.CreateTreemapDiagram(dic, id == 1 ? "buying" : "selling");

        return Content(diagram.ObjToJson());

    }

    public ContentResult Candlestick(string id, string cycle = "Daily")
    {
        cycle = cycle.ToUpper();
        var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();
        var diagram = Signalert.LoadDiagramContent(new Stock { Code = id, }, cycleEnum);

        return Content(diagram);
    }

    public ContentResult Sankey(int id)
    {
        var title = id == 1 ? "dots of buying sets sankey" : "dots of selling sets sankey";

        var records = Signalert.Reportor
            .LoadDotsSankey(Config.DefaultFilter)
            .Where(o => (o.ChangePercent > 0) == (id == 1))
            .ToList();

        var dic = Signalert.Reportor.LoadDotsKey(Config.DefaultFilter, id == 1);

        var diagram = Signalert.Reportor.CreateSankeyDiagram(title, records, dic);

        return Content(diagram.ObjToJson());
    }
}
