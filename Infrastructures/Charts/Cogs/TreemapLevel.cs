using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

public class TreemapLevel
{
    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public ItemStyle? ItemStyle { get; set; }

    [JsonProperty("upperLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? UpperLabel { get; set; }

    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }
}