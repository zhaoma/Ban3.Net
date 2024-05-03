using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Implements.Alpha.Report.Controllers;

public class HomeController : Controller
{
    private ICasinoServer _casino;

    public HomeController(ICasinoServer casino)
    {
        _casino= casino;
    }

    public IActionResult Index()
    {
        var stocks=_casino.LoadStocks();

        return Content(stocks.ObjToJson());
    }
}
