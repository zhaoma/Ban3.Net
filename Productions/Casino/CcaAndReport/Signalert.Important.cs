using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Productions.Casino.Contracts.Response;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    public static bool PrepareFocus(FocusFilter filter, out FocusFilterResult targetsResult)
    {
        var allCodes = Collector.LoadAllCodes();
        return Calculator.PrepareFocus(allCodes, filter, out targetsResult);
    }

    public static Diagram LoadCurrentTreemap(FocusFilter filter)
    {
        var data = Signalert.Calculator.LoadFocus(Config.DefaultFilter);
        var dicCurrent = data.Select(o => o.Value)
            .MergeCurrent();

        return Reportor.CreateTreemapDiagram(Config.DefaultFilter, dicCurrent);
    }
}