using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts.Request;

public class RenderView
{
    public string Id { get; set; }

    public string Cycle { get; set; }

    public StockAnalysisCycle CycleEnum()
       => Cycle.ToUpper().StringToEnum<StockAnalysisCycle>();

    public string StartsWith { get; set; }

    public string EndsWith { get; set; }

    public string ViewName { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}
