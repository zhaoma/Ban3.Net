//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Elements
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHasBorder
    {
        /// <summary>
        /// Background color of title, which is transparent by default.
        /// Color can be represented in RGB, for example 'rgb(128, 128, 128)'. 
        /// RGBA can be used when you need alpha channel, for example 'rgba(128, 128, 128, 0.5)'. 
        /// You may also use hexadecimal format, for example '#ccc'.
        /// </summary>
        [JsonProperty("backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        string? BackgroundColor { get; set; }

        /// <summary>
        /// Stroke color of the text.
        /// </summary>
        [JsonProperty("borderColor", NullValueHandling = NullValueHandling.Ignore)]
        string? BorderColor { get; set; }

        /// <summary>
        /// Stroke line width of the text.
        /// </summary>
        [JsonProperty("borderWidth", NullValueHandling = NullValueHandling.Ignore)]
        int? BorderWidth { get; set; }

        /// <summary>
        /// border type.
        /// </summary>
        [JsonProperty("borderType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        ECharts.BorderType? BorderType { get; set; }

        /// <summary>
        /// The radius of rounded corner. 
        /// Its unit is px. And it supports use array to respectively specify the 4 corner radiuses.
        /// borderRadius: 5,
        /// borderRadius: [5, 5, 0, 0] 
        /// </summary>
        [JsonProperty("borderRadius", NullValueHandling = NullValueHandling.Ignore)]
        object? BorderRadius { get; set; }

        /// <summary>
        /// To set the line dash offset. With borderType , 
        /// we can make the line style more flexible.
        /// </summary>
        [JsonProperty("borderDashOffset", NullValueHandling = NullValueHandling.Ignore)]
        int? BorderDashOffset { get; set; }

        /// <summary>
        /// To specify how to draw the end points of the line.
        /// </summary>
        [JsonProperty("borderCap", NullValueHandling = NullValueHandling.Ignore) ]
        [JsonConverter(typeof(StringEnumConverter))]
        ECharts.BorderCap? BorderCap { get; set; }

        /// <summary>
        /// To determine the shape used to join two line segments where they meet.
        /// </summary>
        [JsonProperty("borderJoin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        ECharts.BorderJoin? BorderJoin { get; set; }

        /// <summary>
        /// To set the miter limit ratio. Only works when borderJoin is set as miter.
        /// Default value is 10. Negative、0、Infinity and NaN values are ignored.
        /// </summary>
        [JsonProperty("borderMiterLimit", NullValueHandling = NullValueHandling.Ignore)]
        int? BorderMiterLimit { get; set; }

        /// <summary>
        /// title space around content.The unit is px.Default values for each position are 5. 
        /// And they can be set to different values with left, right, top, and bottom.
        /// padding: 5
        /// padding: [5, 10]
        /// padding: [
        //    5,   up
        //    10,  right
        //    5,   down
        //    10,  left
        //  ]
        /// </summary>
        [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
        object? Padding { get; set; }
    }
}
