using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Reports;

public class TfvcFilterResult
{
    public TfvcFilterResult()
    {
        Changesets = new();
        Shelvesets = new();
        Identities = new();
        Rows=new();
    }

    public TfvcFilter Filter { get; set; }
    
    public List<CompositeChangeset> Changesets { get; set; }

    public List<CompositeShelveset> Shelvesets { get; set; }
    
    public List<IdentityRef> Identities { get; set; }

    public List<ShowRow> Rows { get; set; }

    public List<ShowRow> PagedRows { get; set; }

    public int TotalPage
    {
        get
        {
            var total = Rows.Count;

            return total % Filter.PageSize > 0
                ? total / Filter.PageSize + 1
                : total / Filter.PageSize;
        }
    }

    public string Pagination
    {
        get
        {
            if (TotalPage <= 1) return string.Empty;

            var sb = new StringBuilder();

            for (var p = Math.Max(1, Filter.PageNo - 4); p <= Math.Min(Filter.PageNo + 5, TotalPage); p++)
            {
                var additionClass = p == Filter.PageNo ? "active" : "";
                sb.AppendLine(
                    $"<li class='page-item)'><a class='page-link {additionClass}' href=\"javascript:;\" onclick=\"return turnPage({p})\">{p}</a></li>");
            }

            return sb.ToString();
        }
    }
}