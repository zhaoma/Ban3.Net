﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

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
        return View();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult One(string id)
    {
        var stock = _casino
            .LoadStocks()
            .First(o => o.Code.Contains(id));
        return View(stock);
    }
}
