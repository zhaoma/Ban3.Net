//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 12:10
//  function:	Geo.cs
//  reference:	https://echarts.apache.org/en/option.html#geo
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Cogs;
using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Ban3.Infrastructures.Charts.Labels;

namespace  Ban3.Infrastructures.Charts.Components;

/// <summary>
/// 地理坐标系组件
/// </summary>
public class Geo
    : GeneralComponent
{
    public string? Map { get; set; }

    public bool? Roam { get; set; }

    public object? Center { get; set; }

    public decimal? AspectScale { get; set; }

    public decimal[][]? boundingCoords { get; set; }

    public decimal? Zoom { get; set; }

    Limit? ScaleLimit { get; set; }

    object? NameMap { get; set; }

    string? NameProperty { get; set; }

    bool? SelectedMode { get; set; }

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

    public object? layoutCenter { get; set; }

    public object? layoutSize { get; set; }


    [JsonProperty("regions", NullValueHandling = NullValueHandling.Ignore)]
    public GeoRegion[]? Regions { get; set; }

    [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Silent { get; set; }



    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }
}
