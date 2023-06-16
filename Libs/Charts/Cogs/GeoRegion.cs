//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Styles;
using  Ban3.Infrastructures.Charts.Labels;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs;

public class GeoRegion
{

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Selected { get; set; }

    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Label? Label { get; set; }


    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }


    [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Select { get; set; }


    [JsonProperty("blur", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Blur { get; set; }


    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }
}