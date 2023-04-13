﻿//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using  Ban3.Infrastructures.Charts.Styles;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Lines
{
    /// <summary>
    /// 坐标轴次刻度线
    /// </summary>
    public class MinorTick
    {
        /// <summary>
        /// Whether to show label.
        /// </summary>
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Show { get; set; } = true;

        /// <summary>
        /// 次刻度线分割数，默认会分割成 5 段
        /// </summary>
        [JsonProperty("splitNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? SplitNumber { get; set; } = 5;

        /// <summary>
        /// 次刻度线的长度。
        /// </summary>
        [JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
        public int? Length { get; set; } = 3;

        /// <summary>
        /// 刻度线样式
        /// </summary>
        [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
        public LineStyle? LineStyle { get; set; }
    }
}