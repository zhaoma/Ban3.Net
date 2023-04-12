//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using System;
using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    public class Restore
    {
        /// <summary>
        /// Whether to show label.
        /// </summary>
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Show { get; set; } = true;

        /// <summary>
        /// 标题文本
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; } = "save as image";

        /// <summary>
        /// 缩放和还原的 icon path
        /// </summary>
        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public object? Icon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iconStyle", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralStyle? IconStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
        public IconEmphasis? Emphasis { get; set; }
    }
}
