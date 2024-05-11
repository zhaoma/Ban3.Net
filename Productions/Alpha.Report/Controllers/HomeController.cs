//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Implements.Alpha.Report.Controllers;

/// <summary>
/// 
/// </summary>
public class HomeController : Controller
{
    private ICasinoServer _casino;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="casino"></param>
    public HomeController(ICasinoServer casino)
    {
        _casino= casino;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        var stocks=_casino.LoadStocks();

        return Content(stocks.ObjToJson());
    }

    public IActionResult One(string id)
    {
        return Content(id);
    }
}
