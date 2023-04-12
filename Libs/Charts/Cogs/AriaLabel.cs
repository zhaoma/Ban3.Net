//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:https://echarts.apache.org/zh/option.html#aria.label
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    /// <summary>
    /// 开启后，会根据图表、数据、标题等情况，自动智能生成关于图表的描述，用户也可以通过配置项修改描述。
    /// </summary>
    public class AriaLabel
    {
        /// <summary>
        /// 是否开启无障碍访问的标签生成。开启后将生成 aria-label 属性。
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 默认采用算法自动生成图表描述，如果用户需要完全自定义，可以将这个值设为描述。
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// 对于图表的整体性描述。
        /// </summary>
        [JsonProperty("general", NullValueHandling = NullValueHandling.Ignore)]
        public AriaLabelGeneral? General { get; set; }


    }
}
