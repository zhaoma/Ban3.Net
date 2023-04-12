//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Ban3.Infrastructures.Charts.Cogs
{

    public class Transform
    {
        /// 
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        /// 
        [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
        public object? Config { get; set; }

        /// 
        [JsonProperty("print", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Print { get; set; }
    }
}
