using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.Casino.Web.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ContentResult CurrentTreemap()
            => Content(Signalert.LoadCurrentTreemap(Config.DefaultFilter).ObjToJson());

        public ContentResult PreviousTreemap()
            => Content(Signalert.LoadPreviousTreemap(Config.DefaultFilter).ObjToJson());

        public ContentResult DotsTreemap(int id = 1)
        {
            var dic = Signalert.LoadDotsKey(Config.DefaultFilter, id == 1);
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
    }
}
