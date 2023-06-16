using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

public enum DataZoomType
{
    /// <summary>
    /// Data zoom functionalities is embeded inside coordinate systems,
    /// enable user to zoom or roam coordinate system by mouse dragging,
    /// mouse move or finger touch (in touch screen).
    /// </summary>
    [Description("inside"), EnumMember(Value = "inside")]
    Inside,

    /// <summary>
    /// A special slider bar is provided,
    /// on which coordinate systems can be zoomed or roamed by mouse dragging or finger touch (in touch screen).
    /// </summary>
    [Description("slider"), EnumMember(Value = "slider")]
    Slider,

    /// <summary>
    /// A marquee tool is provided for zooming or roaming coordinate system.
    /// That is toolbox.feature.dataZoom, which can only be configured in toolbox.
    /// </summary>
    [Description("select"), EnumMember(Value = "select")]
    Select
}