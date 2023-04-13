﻿//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 11:50
//  function:	Polar.cs
//  reference:	https://echarts.apache.org/zh/option.html#polar
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Cogs;
using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using System;
namespace  Ban3.Infrastructures.Charts.Components
{
    /// <summary>
    /// 极坐标系
    /// </summary>
    public class Polar
		:GeneralComponent
	{
		public Polar()
		{
		}

        /// <summary>
        /// 极坐标系的中心（圆心）坐标，数组的第一项是横坐标，第二项是纵坐标。
        /// 支持设置成百分比，设置成百分比时第一项是相对于容器宽度，第二项是相对于容器高度。
        /// center: [400, 300]
        /// center: ['50%', '50%']
        /// </summary>
        [JsonProperty("center", NullValueHandling = NullValueHandling.Ignore)]
        public object? Center { get; set; }

        /// <summary>
        /// 极坐标系的半径。可以为如下类型：
        /// number：直接指定外半径值。
        /// string：例如，'20%'，表示外半径为可视区尺寸（容器高宽中较小一项）的 20% 长度。
        /// Array.number|string：数组的第一项是内半径，第二项是外半径。每一项遵从上述 number string 的描述。
        /// </summary>
        [JsonProperty("radius", NullValueHandling = NullValueHandling.Ignore)]
        public object? Radius { get; set; }

        /// <summary>
        /// 本坐标系特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
        public Tooltip? Tooptip { get; set; }
    }
}
