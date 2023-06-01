//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Composites
{
    /// <summary>
    /// 
    /// </summary>
    public class Diagram
        :Elements.IHasAnimation
    {
        /// <summary>
        /// 标题组件，包含主标题和副标题
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Title[]? Title { get; set; }

        /// <summary>
        /// 图例组件，展现了不同系列的标记(symbol)，颜色和名字
        /// </summary>
        [JsonProperty("legend", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Legend[]? Legend { get; set; }

        /// <summary>
        /// 直角坐标系内绘图网格，
        /// 单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
        /// 可以在网格上绘制折线图，柱状图，散点图（气泡图）。
        /// </summary>
        [JsonProperty("grid", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Grid[]? Grid { get; set; }

        /// <summary>
        /// 直角坐标系 grid 中的 x 轴，一般情况下单个 grid 组件最多只能放上下两个 x 轴，
        /// 多于两个 x 轴需要通过配置 offset 属性防止同个位置多个 x 轴的重叠。
        /// </summary>
        [JsonProperty("xAxis", NullValueHandling = NullValueHandling.Ignore)]
        public Elements.IAxis[]? XAxis { get; set; }

        /// <summary>
        /// 直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，
        /// 多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
        /// </summary>
        [JsonProperty("yAxis", NullValueHandling = NullValueHandling.Ignore)]
        public Elements.IAxis[]? YAxis { get; set; }

        /// <summary>
        /// 极坐标系，可以用于散点图和折线图。每个极坐标系拥有一个角度轴和一个半径轴。
        /// </summary>
        [JsonProperty("polar", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Polar? Polar { get; set; }

        /// <summary>
        /// 极坐标系的径向轴。
        /// </summary>
        [JsonProperty("radiusAxis", NullValueHandling = NullValueHandling.Ignore)]
        public Elements.IAxis? RadiusAxis { get; set; }

        /// <summary>
        /// 极坐标系的角度轴。
        /// </summary>
        [JsonProperty("angleAxis", NullValueHandling = NullValueHandling.Ignore)]
        public Elements.IAxis? AngleAxis { get; set; }

        /// <summary>
        /// 雷达图坐标系组件，只适用于雷达图。该组件等同 ECharts 2 中的 polar 组件。
        /// 因为 3 中的 polar 被重构为标准的极坐标组件，为避免混淆，雷达图使用 radar 组件作为其坐标系。
        /// </summary>
        [JsonProperty("radar", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Radar? Radar { get; set; }

        /// <summary>
        /// dataZoom 组件 用于区域缩放，从而能自由关注细节的数据信息，或者概览数据整体，或者去除离群点的影响。
        /// </summary>
        [JsonProperty("dataZoom", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.DataZoom[]? DataZoom { get; set; }

        /// <summary>
        /// visualMap 是视觉映射组件，用于进行『视觉编码』，也就是将数据映射到视觉元素（视觉通道）。
        /// </summary>
        [JsonProperty("visualMap", NullValueHandling = NullValueHandling.Ignore)]
        public List<Components.VisualMap>? VisualMap { get; set; }

        /// <summary>
        /// 提示框组件
        /// </summary>
        [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.Tooltip[]? Tooltip { get; set; }

        /// <summary>
        /// 这是坐标轴指示器（axisPointer）的全局公用设置。
        /// </summary>
        [JsonProperty("axisPointer", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.AxisPointer? AxisPointer { get; set; }

        /// <summary>
        /// 工具栏。内置有导出图片，数据视图，动态类型切换，数据区域缩放，重置五个工具。
        /// </summary>
        [JsonProperty("toolbox", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.Toolbox? Toolbox { get; set; }

        /// <summary>
        /// brush 是区域选择组件，用户可以选择图中一部分数据，
        /// 从而便于向用户展示被选中数据，或者他们的一些统计计算结果。
        /// </summary>
        [JsonProperty("brush", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.Brush? Brush { get; set; }

        /// <summary>
        /// 地理坐标系组件用于地图的绘制，支持在地理坐标系上绘制散点图，线集。
        /// </summary>
        [JsonProperty("geo", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Geo? Geo { get; set; }

        /// <summary>
        /// 平行坐标系（Parallel Coordinates） 是一种常用的可视化高维数据的图表。
        /// </summary>
        [JsonProperty("parallel", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Parallel? Parallel { get; set; }

        /// <summary>
        /// 平行坐标系（Parallel Coordinates） 是一种常用的可视化高维数据的图表。
        /// </summary>
        [JsonProperty("parallelAxis", NullValueHandling = NullValueHandling.Ignore)]
        public Elements.IAxis? ParallelAxis { get; set; }

        /// <summary>
        /// 单轴。可以被应用到散点图中展现一维数据
        /// </summary>
        [JsonProperty("singleAxis", NullValueHandling = NullValueHandling.Ignore)]
        public Elements.IAxis? SingleAxis { get; set; }

        /// <summary>
        /// timeline 组件，提供了在多个 ECharts option 间进行切换、播放等操作的功能。
        /// </summary>
        [JsonProperty("timeline", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Timeline? Timeline { get; set; }

        /// <summary>
        /// graphic 是原生图形元素组件。可以支持的图形元素包括：
        /// image, text, circle, sector, ring, polygon, polyline, rect, line, bezierCurve, arc, group,
        /// </summary>
        [JsonProperty("graphic", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Graphic? Graphic { get; set; }

        /// <summary>
        /// 日历坐标系组件。
        /// 可以在热力图、散点图、关系图中使用日历坐标系。
        /// </summary>
        [JsonProperty("calendar", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Calendar? Calendar { get; set; }

        /// <summary>
        /// ECharts 4 开始支持了 数据集（dataset）组件用于单独的数据集声明，
        /// 从而数据可以单独管理，被多个组件复用，并且可以自由指定数据到视觉的映射。
        /// </summary>
        [JsonProperty("dataset", NullValueHandling = NullValueHandling.Ignore)]
        public Components.Dataset[]? Dataset { get; set; }

        /// <summary>
        /// 无障碍富互联网应用规范集（WAI-ARIA，the Accessible Rich Internet Applications Suite）
        /// Apache ECharts 4 遵从这一规范，支持自动根据图表配置项智能生成描述，
        /// 使得盲人可以在朗读设备的帮助下了解图表内容，让图表可以被更多人群访问。
        /// 除此之外，Apache ECharts 5 新增支持贴花纹理，作为颜色的辅助表达，进一步用以区分数据。
        /// </summary>
        [JsonProperty("aria", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.Aria? Aria { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("series", NullValueHandling = NullValueHandling.Ignore)]
        public List<Elements.ISeries>? Series { get; set; }

        /// <summary>
        /// 是否是暗黑模式，默认会根据背景色 backgroundColor 的亮度自动设置。 
        /// </summary>
        [JsonProperty("darkMode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DarkMode { get; set; }

        /// <summary>
        /// 调色盘颜色列表。如果系列没有设置颜色，则会依次循环从该列表中取颜色作为系列颜色。 默认为：
        /// ['#5470c6', '#91cc75', '#fac858', '#ee6666', '#73c0de', '#3ba272', '#fc8452', '#9a60b4', '#ea7ccc']
        /// 支持的颜色格式：
        /// 使用 RGB 表示颜色，比如 'rgb(128, 128, 128)'，如果想要加上 alpha 通道表示不透明度，可以使用 RGBA，比如 'rgba(128, 128, 128, 0.5)'，也可以使用十六进制格式，比如 '#ccc'。
        /// 渐变色或者纹理填充
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string? Color { get; set; }

        /// <summary>
        /// 背景色，默认无背景。
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，同color
        /// </summary>
        [JsonProperty("backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// 全局的字体样式。
        /// </summary>
        [JsonProperty("textStyle", NullValueHandling = NullValueHandling.Ignore)]
        public Styles.TextStyle? TextStyle { get; set; }

        #region IHasAnimation

        /// 
        public bool? Animation { get; set; } = true;

        /// 
        public int? AnimationThreshold { get; set; } = 2000;

        /// 
        public object? AnimationDuration { get; set; } = 1000;

        /// 
        public ECharts.EasingEffect? AnimationEasing { get; set; } = ECharts.EasingEffect.CubicOut;

        /// 
        public object? AnimationDelay { get; set; } = 0;

        /// 
        public object? AnimationDurationUpdate { get; set; } = 300;

        /// 
        public ECharts.EasingEffect? AnimationEasingUpdate { get; set; } = ECharts.EasingEffect.CubicInOut;

        /// 
        public object? AnimationDelayUpdate { get; set; } = 0;

        #endregion

        /// <summary>
        /// 状态切换的动画配置，支持在每个系列里设置单独针对该系列的配置。
        /// </summary>
        [JsonProperty("stateAnimation", NullValueHandling = NullValueHandling.Ignore)]
        public Cogs.Animation? StateAnimation { get; set; }

        /// <summary>
        /// 图形的混合模式，
        /// 不同的混合模式见 https://developer.mozilla.org/zh-CN/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation 。
        /// 默认为 'source-over'。 支持每个系列单独设置。
        /// 'lighter' 也是比较常见的一种混合模式，该模式下图形数量集中的区域会颜色叠加成高亮度的颜色（白色）。
        /// </summary>
        [JsonProperty("blendMode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.BlendMode? BlendMode { get; set; }

        /// <summary>
        /// 图形数量阈值，决定是否开启单独的 hover 层，在整个图表的图形数量大于该阈值时开启单独的 hover 层。
        /// </summary>
        [JsonProperty("hoverLayerThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public int? HoverLayerThreshold { get; set; }

        /// <summary>
        /// 是否使用 UTC 时间。
        /// 默认取值为false，即使用本地时间。
        /// </summary>
        [JsonProperty("useUTC", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseUTC { get; set; }

        /// <summary>
        /// 用于 timeline 的 option 数组。数组的每一项是一个 echarts option (ECUnitOption)。
        /// </summary>
        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public object? Options { get; set; }

        /// <summary>
        /// 根据移动端输出（不同屏幕尺寸比例等）
        /// </summary>
        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public List<Cogs.Media>? Media { get; set; }
    }
}
