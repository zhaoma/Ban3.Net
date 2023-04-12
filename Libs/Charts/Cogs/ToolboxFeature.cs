﻿//  ————————————————————————————————————————————————————————————————————————————
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
    /// <summary>
    /// 
    /// </summary>
    public class ToolboxFeature
    {
        /// <summary>
        /// Whether to show label.
        /// </summary>
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Show { get; set; } = true;


    }
}
