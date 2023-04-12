//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:21
//  function:	单轴。可以被应用到散点图中展现一维数据。
//  reference:	https://echarts.apache.org/en/option.html#singleAxis
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Cogs;
using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Axes
{
    /// <summary>
    /// 单轴
    /// </summary>
    public class SingleAxis
       : GeneralAxis,IHasPosition
    {
        public SingleAxis()
        {
        }

        #region IHasPosition

        /// 
        public object? Left { get; set; } = "auto";

        /// 
        public object? Top { get; set; } = "auto";

        /// 
        public object? Right { get; set; } = "auto";

        /// 
        public object? Bottom { get; set; } = "auto";

        ///
        public object? Width { get; set; } = "auto";

        /// 
        public object? Height { get; set; } = "auto";

        #endregion

        /// <summary>
        /// The layout orientation of legend.
        /// </summary>
        [JsonProperty("orient", NullValueHandling = NullValueHandling.Ignore)]
	    [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.Orient? Orient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
        public Tooltip? Tooltip { get; set; }
    }
}

