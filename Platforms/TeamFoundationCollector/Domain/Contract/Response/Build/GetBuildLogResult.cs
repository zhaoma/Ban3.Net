using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Build;

public class GetBuildLogResult
:IResponse
{
    public bool Success { get; set; }

    public string Content { get; set; } = string.Empty;
}