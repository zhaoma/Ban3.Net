// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// 
public enum GraphicElementType
{
    /// 
    [Description("image"), EnumMember(Value = "image")]
    Image,

    /// 
    [Description("text"), EnumMember(Value = "text")]
    Text,

    /// 
    [Description("circle"), EnumMember(Value = "circle")]
    Circle,

    /// 
    [Description("sector"), EnumMember(Value = "sector")]
    Sector,

    /// 
    [Description("ring"), EnumMember(Value = "ring")]
    Ring,

    /// 
    [Description("polygon"), EnumMember(Value = "polygon")]
    Polygon,

    /// 
    [Description("polyline"), EnumMember(Value = "polyline")]
    Polyline,

    /// 
    [Description("rect"), EnumMember(Value = "rect")]
    Rect,

    /// 
    [Description("line"), EnumMember(Value = "line")]
    Line,

    /// 
    [Description("bezierCurve"), EnumMember(Value = "bezierCurve")]
    BezierCurve,

    /// 
    [Description("arc"), EnumMember(Value = "arc")]
    Arc,

    /// 
    [Description("group"), EnumMember(Value = "group")]
    Group
}