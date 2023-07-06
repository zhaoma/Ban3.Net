using System;
using System.Security.Policy;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Request;

public class RenderView
{
    [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty("cycle", NullValueHandling = NullValueHandling.Ignore)]
    public string Cycle { get; set; }

    [JsonProperty("redOnly", NullValueHandling = NullValueHandling.Ignore)]
    public int? RedOnly { get; set; }

    [JsonProperty("greenOnly", NullValueHandling = NullValueHandling.Ignore)]
    public int? GreenOnly { get; set; }

    public StockAnalysisCycle CycleEnum()
       => Cycle.ToUpper().StringToEnum<StockAnalysisCycle>();

    [JsonProperty("startsWith", NullValueHandling = NullValueHandling.Ignore)]
    public string StartsWith { get; set; }

    [JsonProperty("endsWith", NullValueHandling = NullValueHandling.Ignore)]
    public string EndsWith { get; set; }

    [JsonProperty("includeKeys", NullValueHandling = NullValueHandling.Ignore)]
    public string IncludeKeys { get; set; }

    [JsonProperty("excludeKeys", NullValueHandling = NullValueHandling.Ignore)]
    public string ExcludeKeys { get; set; }

    [JsonProperty("viewName", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewName { get; set; }

    [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
    public int Page { get; set; } = 1;

    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int PageSize { get; set; } = 50;

    [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
    public int Total { get; set; }

    [JsonProperty("renderElement", NullValueHandling = NullValueHandling.Ignore)]
    public string RenderElement { get; set; }

    [JsonProperty("dataUrl", NullValueHandling = NullValueHandling.Ignore)]
    public string DataUrl { get; set; }

    public string Pagination()
    {
        if (Total <= PageSize || PageSize == 0) return "";

        var sb = new StringBuilder();

        sb.AppendLine(@"<nav aria-label=""Page navigation example""><ul class=""pagination justify-content-end"">");

        var pageCount = Total % PageSize > 0 ? Total / PageSize + 1 : Total / PageSize;

        var start =pageCount>10? Math.Max(Page - 3, 1):1;
        var end = pageCount > 10 ? Math.Min(pageCount, Page + 3):pageCount;

        sb.AppendLine(Page > 1
            ? $"<li class=\"page-item\"><a class=\"page-link lazyLoadButton\" onclick='return bindButton(this);' renderElement=\"{RenderElement}\" dataUrl=\"{Url(p: Page - 1)}\" href=\"{Url(p: Page - 1)}\">&lt;</a></li>"
            : "<li class=\"page-item disabled\"> <a class=\"page-link\" href=\"#\" tabindex=\"-1\" aria-disabled=\"true\">&lt;</a></li>");

        for (var p = start; p <= end; p++)
        {
            var url=Url(p);
            sb.AppendLine(p == Page
                ? $"<li class=\"page-item active\" aria-current=\"page\"><span class=\"page-link\">{p}</span></li>"
                : $"<li class=\"page-item\"><a class=\"page-link lazyLoadButton\" onclick='return bindButton(this);' renderElement=\"{RenderElement}\" dataUrl=\"{url}\" href=\"{url}\">{p}</a></li>");
        }

        sb.AppendLine(Page <pageCount
            ? $"<li class=\"page-item\"><a class=\"page-link lazyLoadButton\" onclick='return bindButton(this);' renderElement=\"{RenderElement}\" dataUrl=\"{Url(p: Page + 1)}\" href=\"{Url(p: Page + 1)}\">&gt;</a></li>"
            : "<li class=\"page-item disabled\"> <a class=\"page-link\" href=\"#\" tabindex=\"-1\" aria-disabled=\"true\">&gt;</a></li>");

        sb.AppendLine(@" </ul></nav>");

        return sb.ToString();
    }

    string Url(int p)
    {
        var sb = new StringBuilder();
        sb.Append($"{DataUrl}?pageSize={PageSize}&page={p}&renderElement={RenderElement}&dataUrl={DataUrl}");
        if (RedOnly == 1)
            sb.Append($"&redOnly={RedOnly}");
        if (GreenOnly == 1)
            sb.Append($"&greenOnly={GreenOnly}");
        if (!string.IsNullOrEmpty(StartsWith))
            sb.Append($"&startsWith={StartsWith}");
        if (!string.IsNullOrEmpty(EndsWith))
            sb.Append($"&endsWith={EndsWith}");
        if (!string.IsNullOrEmpty(IncludeKeys))
            sb.Append($"&includeKeys={IncludeKeys}");
        if (!string.IsNullOrEmpty(ExcludeKeys))
            sb.Append($"&excludeKeys={ExcludeKeys}");

        return sb.ToString();
    }
}
