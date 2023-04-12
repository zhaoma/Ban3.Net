//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Styles;
using  Ban3.Infrastructures.Charts.Labels;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    public class Progress
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
        public LineStyle? LineStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralStyle? ItemStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public Label? Label { get; set; }

    }
}
