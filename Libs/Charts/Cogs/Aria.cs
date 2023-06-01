//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:26
//  function:	the Accessible Rich Internet Applications Suite
//  reference:	https://echarts.apache.org/en/option.html#aria
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    /// <summary>
    /// 无障碍富互联网应用规范集
    /// </summary>
    public class Aria
    {
        /// <summary>
        /// 是否开启无障碍访问
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 开启后，会根据图表、数据、标题等情况，自动智能生成关于图表的描述，用户也可以通过配置项修改描述。
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public AriaLabel? Label { get; set; }

        /// 
        [JsonProperty("decal", NullValueHandling = NullValueHandling.Ignore)]
        public AriaDecal? Decal { get; set; }
    }
}

