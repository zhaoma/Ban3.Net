using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// 要在绘制新形状时应用的合成操作的类型
    /// </summary>
    public enum BlendMode
    {
        /// <summary>
        /// 这是默认设置，并在现有画布上下文之上绘制新图形。
        /// </summary>
        [Description("source-over"), EnumMember(Value = "source-over")]
        SourceOver,

        /// <summary>
        /// 新图形只在新图形和目标画布重叠的地方绘制。其他的都是透明的。
        /// </summary>
        [Description("source-in"), EnumMember(Value = "source-in")]
        SourceIn,

        /// <summary>
        /// 在不与现有画布内容重叠的地方绘制新图形。
        /// </summary>
        [Description("source-out"), EnumMember(Value = "source-out")]
        SourceOut,

        /// <summary>
        /// 新图形只在与现有画布内容重叠的地方绘制。
        /// </summary>
        [Description("source-atop"), EnumMember(Value = "source-atop")]
        SourceAtop,

        /// <summary>
        /// 在现有的画布内容后面绘制新的图形。
        /// </summary>
        [Description("destination-over"), EnumMember(Value = "destination-over")]
        DestinationOver,

        /// <summary>
        /// 现有的画布内容保持在新图形和现有画布内容重叠的位置。其他的都是透明的。
        /// </summary>
        [Description("destination-in"), EnumMember(Value = "destination-in")]
        DestinationIn,

        /// <summary>
        /// 现有内容保持在新图形不重叠的地方。
        /// </summary>
        [Description("destination-out"), EnumMember(Value = "destination-out")]
        DestinationOut,

        /// <summary>
        /// 现有的画布只保留与新图形重叠的部分，新的图形是在画布内容后面绘制的。
        /// </summary>
        [Description("destination-atop"), EnumMember(Value = "destination-atop")]
        DestinationAtop,

        /// <summary>
        /// 两个重叠图形的颜色是通过颜色值相加来确定的。
        /// </summary>
        [Description("lighter"), EnumMember(Value = "lighter")]
        Lighter,

        /// <summary>
        /// 只显示新图形。
        /// </summary>
        [Description("copy"), EnumMember(Value = "copy")]
        Copy,

        /// <summary>
        /// 图像中，那些重叠和正常绘制之外的其他地方是透明的。
        /// </summary>
        [Description("xor"), EnumMember(Value = "xor")]
        Xor,

        /// <summary>
        /// 将顶层像素与底层相应像素相乘，结果是一幅更黑暗的图片。
        /// </summary>
        [Description("multiply"), EnumMember(Value = "multiply")]
        Multiply,

        /// <summary>
        /// 像素被倒转，相乘，再倒转，结果是一幅更明亮的图片。
        /// </summary>
        [Description("screen"), EnumMember(Value = "screen")]
        Screen,

        /// <summary>
        /// multiply 和 screen 的结合，原本暗的地方更暗，原本亮的地方更亮。
        /// </summary>
        [Description("overlay"), EnumMember(Value = "overlay")]
        Overlay,

        /// <summary>
        /// 保留两个图层中最暗的像素。
        /// </summary>
        [Description("darken"), EnumMember(Value = "darken")]
        Darken,

        /// <summary>
        /// 保留两个图层中最亮的像素。
        /// </summary>
        [Description("lighten"), EnumMember(Value = "lighten")]
        Lighten,

        /// <summary>
        /// 将底层除以顶层的反置。
        /// </summary>
        [Description("color-dodge"), EnumMember(Value = "color-dodge")]
        ColorDodge,

        /// <summary>
        /// 将反置的底层除以顶层，然后将结果反过来。
        /// </summary>
        [Description("color-burn"), EnumMember(Value = "color-burn")]
        ColorBurn,

        /// <summary>
        /// 屏幕相乘（A combination of multiply and screen）类似于叠加，但上下图层互换了。
        /// </summary>
        [Description("hard-light"), EnumMember(Value = "hard-light")]
        HardLight,

        /// <summary>
        /// 用顶层减去底层或者相反来得到一个正值。
        /// </summary>
        [Description("soft-light"), EnumMember(Value = "soft-light")]
        SoftLight,

        /// <summary>
        /// 一个柔和版本的强光（hard-light）。纯黑或纯白不会导致纯黑或纯白。
        /// </summary>
        [Description("difference"), EnumMember(Value = "difference")]
        Difference,

        /// <summary>
        /// 和 difference 相似，但对比度较低。
        /// </summary>
        [Description("exclusion"), EnumMember(Value = "exclusion")]
        Exclusion,

        /// <summary>
        /// 保留了底层的亮度（luma）和色度（chroma），同时采用了顶层的色调（hue）。
        /// </summary>
        [Description("hue"), EnumMember(Value = "hue")]
        Hue,

        /// <summary>
        /// 保留底层的亮度（luma）和色调（hue），同时采用顶层的色度（chroma）。
        /// </summary>
        [Description("saturation"), EnumMember(Value = "saturation")]
        Saturation,

        /// <summary>
        /// 保留了底层的亮度（luma），同时采用了顶层的色调 (hue) 和色度 (chroma)。
        /// </summary>
        [Description("color"), EnumMember(Value = "color")]
        Color,

        /// <summary>
        /// 保持底层的色调（hue）和色度（chroma），同时采用顶层的亮度（luma）。
        /// </summary>
        [Description("luminosity"), EnumMember(Value = "luminosity")]
        Luminosity
    }
}
