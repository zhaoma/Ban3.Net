// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Ban3.Infrastructures.Charts.Labels;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// 地理坐标系组件
/// https://echarts.apache.org/en/option.html#geo
/// </summary>
public class Geo
    : GeneralComponent
{
    [JsonProperty("map", NullValueHandling = NullValueHandling.Ignore)]
    public string? Map { get; set; }

    [JsonProperty("roam", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Roam { get; set; }

    [JsonProperty("center", NullValueHandling = NullValueHandling.Ignore)]
    public object? Center { get; set; }

    [JsonProperty("aspectScale", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? AspectScale { get; set; }

    [JsonProperty("boundingCoords", NullValueHandling = NullValueHandling.Ignore)]
    public decimal[][]? BoundingCoords { get; set; }

    [JsonProperty("zoom", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Zoom { get; set; }

    [JsonProperty("scaleLimit", NullValueHandling = NullValueHandling.Ignore)]
    public Limit? ScaleLimit { get; set; }

    [JsonProperty("nameMap", NullValueHandling = NullValueHandling.Ignore)]
    public object? NameMap { get; set; }

    [JsonProperty("nameProperty", NullValueHandling = NullValueHandling.Ignore)]
    public string? NameProperty { get; set; }

    [JsonProperty("selectedMode", NullValueHandling = NullValueHandling.Ignore)]
    public bool? SelectedMode { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Label? Label { get; set; }
    
    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }
    
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }

    [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Select { get; set; }


    [JsonProperty("blur", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Blur { get; set; }

    [JsonProperty("layoutCenter", NullValueHandling = NullValueHandling.Ignore)]
    public object? LayoutCenter { get; set; }

    [JsonProperty("layoutSize", NullValueHandling = NullValueHandling.Ignore)]
    public object? LayoutSize { get; set; }


    [JsonProperty("regions", NullValueHandling = NullValueHandling.Ignore)]
    public GeoRegion[]? Regions { get; set; }

    [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Silent { get; set; }
    
    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }
}
