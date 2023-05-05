using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Reports;

public class TfvcFilterResult
{
    public TfvcFilter Filter { get; set; }
    
    public CountedResult<CompositeChangeset> Changesets { get; set; }

    public CountedResult<CompositeChangeset> Shelvesets { get; set; }


}