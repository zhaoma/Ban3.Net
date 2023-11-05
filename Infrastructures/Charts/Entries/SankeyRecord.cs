// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Entries;

public class SankeyRecord
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;


    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public ItemStyle? ItemStyle { get; set; }
}
