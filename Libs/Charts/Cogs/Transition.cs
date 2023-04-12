//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    public class Transition
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("seriesKey", NullValueHandling = NullValueHandling.Ignore)]
        public string? SeriesKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("divideShape", NullValueHandling = NullValueHandling.Ignore)]
        public ECharts.DivideShape? DivideShape { get; set; }


    }
}
