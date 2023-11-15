// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Response;

public class TushareResponse
{
    class ApiResponseData
    {
        /// <summary>
        /// 索取的字段
        /// </summary>
        [JsonProperty( "fields" )]
        public List<string> Fields { get; set; } = new();

        /// <summary>
        /// 索取结果数组的集合
        /// </summary>
        [JsonProperty( "items" )]
        public List<List<string>> Items { get; set; } = new();
    }
}