using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

public class ApiResponseData
{
    [JsonProperty("fields")] public List<string> Fields { get; set; } = new();

    [JsonProperty("items")] public List<List<string>> Items { get; set; } = new();
}