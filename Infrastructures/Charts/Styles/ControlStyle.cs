//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Styles
{
    /// 
    public class ControlStyle
        : GeneralStyle
    {
        /// 
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Show { get; set; } = true;

        /// 
        [JsonProperty("showPlayBtn", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowPlayBtn { get; set; }

        /// 
        [JsonProperty("showPrevBtn", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowPrevBtn { get; set; }

        /// 
        [JsonProperty("showNextBtn", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowNextBtn { get; set; }

        /// 
        [JsonProperty("itemSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? ItemSize { get; set; }

        /// 
        [JsonProperty("itemGap", NullValueHandling = NullValueHandling.Ignore)]
        public int? ItemGap { get; set; }

        /// 
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public ECharts.Position? Position { get; set; }

        /// 
        [JsonProperty("playIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string? PlayIcon { get; set; }

        /// 
        [JsonProperty("stopIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string? StopIcon { get; set; }

        /// 
        [JsonProperty("prevIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string? PrevIcon { get; set; }

        /// 
        [JsonProperty("nextIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string? NextIcon { get; set; }
    }
}
