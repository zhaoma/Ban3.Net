//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:34
//  function:	SeriesType.cs
//  reference:	https://echarts.apache.org/zh/option.html#series
//  ————————————————————————————————————————————————————————————————————————————
using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum SeriesType
    {
        /// <summary>
        /// 折线图是用折线将各个数据点标志连接起来的图表，用于展现数据的变化趋势。
	    /// 可用于直角坐标系和极坐标系上。
        /// </summary>
		[Description("折线/面积图"),EnumMember(Value = "line")]
        Line,

        /// <summary>
        /// 柱状图（或称条形图）是一种通过柱形的高度（横向的情况下则是宽度）来表现数据大小的一种常用图表类型。
        /// </summary>
		[Description("柱状图"), EnumMember(Value = "bar")]
		Bar,

        /// <summary>
        /// 饼图主要用于表现不同类目的数据在总和中的占比。每个的弧度表示数据数量的比例。
        /// </summary>
        [Description("饼图"), EnumMember(Value = "pie")]
        Pie,

        /// <summary>
        /// 直角坐标系上的散点图可以用来展现数据的 x，y 之间的关系，如果数据项有多个维度，
	    /// 其它维度的值可以通过不同大小的 symbol 展现成气泡图，也可以用颜色来表现。
	    /// 这些可以配合 visualMap 组件完成。
        /// </summary>
        [Description("散点（气泡）图"), EnumMember(Value = "scatter")]
        Scatter,

        /// <summary>
        /// 带有涟漪特效动画的散点（气泡）图。
        /// 利用动画特效可以将某些想要突出的数据进行视觉突出。
        /// </summary>
        [Description("涟漪散点图"), EnumMember(Value = "effectScatter")]
        EffectScatter,

        /// <summary>
        /// 雷达图主要用于表现多变量的数据，例如球员的各个属性分析。依赖 radar 组件。
        /// </summary>
        [Description("雷达图"), EnumMember(Value = "radar")]
        Radar,

        /// <summary>
        /// 树图主要用来可视化树形数据结构，是一种特殊的层次类型，具有唯一的根节点，左子树，和右子树。
        /// </summary>
        [Description("树图"), EnumMember(Value = "tree")]
        Tree,

        /// <summary>
        /// Treemap 是一种常见的表达『层级数据』『树状数据』的可视化形式。
        /// 主要用面积的方式，便于突出展现出『树』的各层级中重要的节点。
        /// </summary>
        [Description("treemap"), EnumMember(Value = "treemap")]
        Treemap,

        /// <summary>
        /// 旭日图（Sunburst）由多层的环形图组成，在数据结构上，内圈是外圈的父节点。
	    /// 因此，它既能像饼图一样表现局部和整体的占比，又能像矩形树图一样表现层级关系。
        /// </summary>
        [Description("旭日图"), EnumMember(Value = "sunburst")]
        Sunburst,

        /// <summary>
        /// Boxplot 中文可以称为『箱形图』、『盒须图』、『盒式图』、『盒状图』、『箱线图』，
	    /// 是一种用作显示一组数据分散情况资料的统计图。它能显示出一组数据的最大值、最小值、中位数、下四分位数及上四分位数。
        /// </summary>
        [Description("箱形图"), EnumMember(Value = "boxplot")]
        Boxplot,

        /// <summary>
        /// Candlestick 即我们常说的 K线图。
        /// </summary>
        [Description("K线图"), EnumMember(Value = "candlestick")]
        Candlestick,

        /// <summary>
        /// 热力图主要通过颜色去表现数值的大小，必须要配合 visualMap 组件使用。
        /// </summary>
        [Description("热力图"), EnumMember(Value = "heatmap")]
        Heatmap,

        /// <summary>
        /// 地图主要用于地理区域数据的可视化，配合 visualMap 组件用于展示不同区域的人口分布密度等数据。
        /// </summary>
        [Description("地图"), EnumMember(Value = "map")]
        Map,

        /// <summary>
        /// 平行坐标系（Parallel Coordinates） 是一种常用的可视化高维数据的图表。
        /// </summary>
        [Description("平行坐标系"), EnumMember(Value = "parallel")]
        Parallel,

        /// <summary>
        /// 用于带有起点和终点信息的线数据的绘制，主要用于地图上的航线，路线的可视化。
        /// </summary>
        [Description("Lines"), EnumMember(Value = "lines")]
        Lines,

        /// <summary>
        /// 用于展现节点以及节点之间的关系数据
        /// </summary>
        [Description("关系图"), EnumMember(Value = "graph")]
        Graph,

        /// <summary>
        /// 桑基图是一种特殊的流图（可以看作是有向无环图）。 
	    /// 它主要用来表示原材料、能量等如何从最初形式经过中间过程的加工或转化达到最终状态。
        /// </summary>
        [Description("桑基图"), EnumMember(Value = "effectScatter")]
        Sankey,

        /// <summary>
        /// 漏斗图
        /// </summary>
        [Description("漏斗图"), EnumMember(Value = "funnel")]
        Funnel,

        /// <summary>
        /// 仪表盘
        /// </summary>
        [Description("仪表盘"), EnumMember(Value = "gauge")]
        Gauge,

        /// <summary>
        /// 象形柱图是可以设置各种具象图形元素（如图片、SVG PathData 等）的柱状图。
	    /// 往往用在信息图中。用于有至少一个类目轴或时间轴的直角坐标系上。
        /// </summary>
        [Description("象形柱图"), EnumMember(Value = "pictorialBar")]
        PictorialBar,

        /// <summary>
        /// 主题河流是一种特殊的流图, 它主要用来表示事件或主题等在一段时间内的变化。
        /// </summary>
        [Description("主题河流"), EnumMember(Value = "themeRiver")]
        ThemeRiver,

        /// <summary>
        /// 自定义系列可以自定义系列中的图形元素渲染。从而能扩展出不同的图表。
        /// </summary>
        [Description("自定义"), EnumMember(Value = "custom")]
        Custom
    }
}

