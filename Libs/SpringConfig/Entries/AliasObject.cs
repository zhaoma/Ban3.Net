using Newtonsoft.Json;

namespace Ban3.Infrastructures.SpringConfig.Entries;

public class AliasObject
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("alias")]
    public string Alias { get; set; }

}