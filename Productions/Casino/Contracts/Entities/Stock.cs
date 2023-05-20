using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class Stock
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonProperty("listDate")]
    public string ListDate { get; set; }
}