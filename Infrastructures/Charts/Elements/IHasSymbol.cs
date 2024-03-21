// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Elements;

public interface IHasSymbol
{
    /// <summary>
    /// Icon types provided by ECharts includes
    /// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
    /// It can be set to an image with 'image://url' , in which URL is the link to an image, or dataURI of an image.
    /// Icons can be set to arbitrary vector path via 'path://' in ECharts.
    /// </summary>
    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    object? Symbol { get; set; }

    /// <summary>
    /// timeline symbol size. It can be set to single numbers like 10, 
    /// or use an array to represent width and height. 
    /// For example, [20, 10] means symbol width is 20, and height is10.
    /// </summary>
    [JsonProperty("symbolSize", NullValueHandling = NullValueHandling.Ignore)]
    object? SymbolSize { get; set; }

    /// <summary>
    /// Rotate degree of timeline symbol. The negative value represents clockwise. 
    /// Note that when symbol is set to be 'arrow' in markLine, 
    /// symbolRotate value will be ignored, and compulsively use tangent angle.
    /// </summary>
    [JsonProperty("symbolRotate", NullValueHandling = NullValueHandling.Ignore)]
    int? SymbolRotate { get; set; }

    /// <summary>
    /// Whether to keep aspect for symbols in the form of path://.
    /// </summary>
    [JsonProperty("symbolKeepAspect", NullValueHandling = NullValueHandling.Ignore)]
    bool? SymbolKeepAspect { get; set; }

    /// <summary>
    /// Offset of timeline symbol relative to original position. 
    /// By default, symbol will be put in the center position of data. 
    /// But if symbol is from user-defined vector path or image, 
    /// you may not expect symbol to be in center. In this case, 
    /// you may use this attribute to set offset to default position. 
    /// It can be in absolute pixel value, or in relative percentage value.
    /// </summary>
    [JsonProperty("symbolOffset", NullValueHandling = NullValueHandling.Ignore)]
    object? SymbolOffset { get; set; }
}