//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 12:08
//  function:	区域选择组件
//  reference:	https://echarts.apache.org/en/option.html#brush
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    /// <summary>
    /// 区域选择组件，用户可以选择图中一部分数据，从而便于向用户展示被选中数据，或者他们的一些统计计算结果。
    /// 目前 brush 组件支持的图表类型：scatter、bar、candlestick（parallel 本身自带刷选功能，但并非由 brush 组件来提供）。
    /// 点击 toolbox 中的按钮，能够进行『区域选择』、『清除选择』等操作。
    /// </summary>
    public class Brush
    {
        public Brush()
        {
        }

        /// 
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.BrushType? Type { get; set; }

        /// <summary>
        /// icon path for each icon.
        /// </summary>
        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public BrushSetting? Icon { get; set; }

        /// <summary>
        /// title for each icon.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public BrushSetting? Title { get; set; }
    }
}

