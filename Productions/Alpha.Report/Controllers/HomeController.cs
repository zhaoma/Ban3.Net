using Microsoft.AspNetCore.Mvc;

namespace Ban3.Implements.Alpha.Report.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
