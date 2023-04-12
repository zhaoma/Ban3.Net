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
    /// <summary>
    /// The icons of page buttons.
    /// It works when legend.type is 'scroll'.
    /// </summary>
    public class PageIcons
    {
        /// <summary>
        /// The icons of page buttons when legend.orient is 'horizontal'.
        /// It should be an array, [previous page button, next page button], ['M0,0L20,0L10,-20z', 'M0,0L20,0L10,20z'] by default.
        /// For the each item of the array,
        /// It can be set to an image with 'image://url' ,
        /// Icons can be set to arbitrary vector path via 'path://' in ECharts.
        /// </summary>
        [JsonProperty("horizontal", NullValueHandling = NullValueHandling.Ignore)]
        public Array? Horizontal { get; set; }

        /// <summary>
        /// The icons of page buttons when legend.orient is 'vertical'.
        /// It should be an array, [previous page button, next page button], ['M0,0L20,0L10,-20z', 'M0,0L20,0L10,20z'] by default.
        /// For the each item of the array,
        /// It can be set to an image with 'image://url' ,
        /// Icons can be set to arbitrary vector path via 'path://' in ECharts.
        /// </summary>
        [JsonProperty("vertical", NullValueHandling = NullValueHandling.Ignore)]
        public Array? Vertical { get; set; }

    }
}
