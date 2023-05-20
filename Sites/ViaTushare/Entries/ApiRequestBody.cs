using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Entries;

public class ApiRequestBody
{
    [JsonProperty("api_name")] public string ApiName { get; set; } = string.Empty;

    [JsonProperty("token")] public string Token { get; set; }= @"dac6b901ec28c2fd99e62afd8b250f8c171e4d3a474ae1b0633903d0";

    [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)] 
    public Dictionary<string, object>? Params { get; set; }

    [JsonProperty("fields")] public string Fields => string.Join(",", FieldList);

    [JsonIgnore] public List<string> FieldList { get; set; }=new ();
}