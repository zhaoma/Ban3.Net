//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Implements.Alpha.Report.Controllers;

/// <summary>
/// 
/// </summary>
public class DataController : Controller
{
    private ICasinoServer _casino;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="casino"></param>
    public DataController(ICasinoServer casino)
    {
        _casino = casino;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Treemap()
        => Content(_casino.LoadTreemapDiagram());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult Candlestick(string id)
        => Content(_casino.LoadCandlestickDiagram(new Infrastructures.Contracts.Entries.CasinoServer.Stock { Code = id }));
}
