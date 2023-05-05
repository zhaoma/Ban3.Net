using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class IdentitySummary
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;
    
    [JsonProperty("changesets")]
    public Dictionary<string,CompositeChangeset>? Changesets { get; set; }

    [JsonProperty("shelvesets")]
    public Dictionary<string,CompositeShelveset>? Shelvesets { get; set; }
    
}