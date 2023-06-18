using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string id)
    {
        return string.IsNullOrEmpty(id)
            ? View()
            : View(id);
    }
}