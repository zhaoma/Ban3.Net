//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Lines;

/// <summary>
/// 标签的视觉引导线
/// </summary>
public class LabelLine
    : GeneralLine
{
    /// <summary>
    /// 是否显示在图形上方。
    /// </summary>
    [JsonProperty("showAbove", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShowAbove { get; set; }

    /// <summary>
    /// 视觉引导项第二段的长度
    /// </summary>
    [JsonProperty("length2", NullValueHandling = NullValueHandling.Ignore)]
    public int? Length2 { get; set; }

    /// <summary>
    /// 是否平滑视觉引导线，默认不平滑，
    /// 可以设置成 true 平滑显示，
    /// 也可以设置为 0 到 1 的值，表示平滑程度。
    /// </summary>
    [JsonProperty("smooth", NullValueHandling = NullValueHandling.Ignore)]
    public object? Smooth { get; set; }

    /// <summary>
    /// 通过调整第二段线的长度，限制引导线两端之间最小的夹角，以防止过小的夹角导致显示不美观。
    /// 可以设置为 0 - 180 度。
    /// </summary>
    [JsonProperty("minTurnAngle", NullValueHandling = NullValueHandling.Ignore)]
    public int? MinTurnAngle { get; set; }
}