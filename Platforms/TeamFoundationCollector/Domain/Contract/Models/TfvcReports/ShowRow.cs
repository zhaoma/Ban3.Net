using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

public class ShowRow
{
    public ReportRef ReportRef { get; set; }

    public string Id { get; set; } = string.Empty;
    public string FileId { get; set; } = string.Empty;

    public string AuthorGuid { get; set; } = string.Empty;

    public string AuthorName { get; set; } = string.Empty;

    public string CreatedDate { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;

    public List<TfvcChange>? Changes { get; set; }

    public string Url { get; set; } = string.Empty;
    
    public List<CompositeThread>? Threads { get; set; }
}