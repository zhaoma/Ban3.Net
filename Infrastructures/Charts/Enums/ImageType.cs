// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// 保存的图片格式
/// </summary>
public enum ImageType
{
    /// 
    [Description("canvas"), EnumMember(Value = "canvas")]
    Canvas,

    /// 
    [Description("png"), EnumMember(Value = "png")]
    Png,

    /// 
    [Description("jpg"), EnumMember(Value = "jpg")]
    Jpg,

    /// 
    [Description("svg"), EnumMember(Value = "svg")]
    Svg
}
