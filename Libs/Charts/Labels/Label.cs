//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Labels
{
    /// <summary>
    /// Text label of , to explain some data information about graphic item like value, name and so on.
    /// </summary>
    public class Label
        :GeneralLabel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.Position? Position { get; set; }

        /// <summary>
        /// Distance to the host graphic element.
        /// </summary>
        [JsonProperty("distance", NullValueHandling = NullValueHandling.Ignore)]
        public int? Distance { get; set; } = 5;

        /// <summary>
        /// Rotate label, from -90 degree to 90, positive value represents rotate anti-clockwise.
        /// </summary>
        [JsonProperty("rotate", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rotate { get; set; }

        /// <summary>
        /// Whether to move text slightly. 
        /// For example: [30, 40] means move 30 horizontally and move 40 vertically.
        /// </summary>
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public Array? Offset { get; set; }

        /// <summary>
        /// Data label formatter, which supports string template and callback function. In either form, \n is supported to represent a new line.
        /// String template
        /// Model variation includes:
        /// {a}: series name.
        /// {b}: the name of a data item.
        /// {c}: the value of a data item.
        /// {@xxx}: the value of a dimension named 'xxx', for example, {@product} refers the value of 'product' dimension.
        /// {@[n]}: the value of a dimension at the index of n, for example, {@[3]} refers the value at dimensions[3].
        /// </summary>
        [JsonProperty("formatter", NullValueHandling = NullValueHandling.Ignore)]
        public object? Formatter { get; set; }

        /// <summary>
        /// 文字超出宽度是否截断或者换行。
        /// </summary>
        [JsonProperty("overflow", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.Overflow? Overflow { get; set; }

        /// <summary>
        /// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
        /// </summary>
        [JsonProperty("ellipsis", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ellipsis { get; set; }

        /// <summary>
        /// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
        /// </summary>
        [JsonProperty("rich", NullValueHandling = NullValueHandling.Ignore)]
        public object? Rich { get; set; }
    }
}
