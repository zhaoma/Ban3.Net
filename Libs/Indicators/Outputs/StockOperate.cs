/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的操作）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 标的操作
    /// </summary>
    public class StockOperate
            : StockLog
    {
        /// ctor
        public StockOperate() {}

        /// <summary>
        /// 建议操作
        /// </summary>
        [JsonProperty("operate")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.StockOperate Operate { get; set; }

        /// <summary>
        /// 操作是否正确
        /// </summary>
        [JsonProperty("isRight")]
        public bool IsRight { get; set; }

        [JsonProperty("keys")] public List<string> Keys { get; set; } = new();
    }
}