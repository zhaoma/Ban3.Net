using System.Collections.Generic;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;

public class Guideline
{
    public string Id { get; set; }

    public Dictionary<string, string> NameAndVersions { get; set; }
}