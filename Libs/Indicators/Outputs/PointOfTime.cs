/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出时间点）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Runtime.Serialization;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Outputs.Values;

namespace Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 某个时间点的索引值组
    /// </summary>
    public class PointOfTime
            : Record
    {
        /// <summary>
        /// 成交额
        /// </summary>
        [DataMember( Name = "Amount" )]
        public AMOUNT Amount { get; set; }

        /// <summary>
        /// 乖离
        /// </summary>
        [DataMember( Name = "Bias" )]
        public BIAS Bias { get; set; }

        /// <summary>
        /// 顺势指标(唐纳德·蓝伯特)
        /// </summary>
        [DataMember( Name = "Cci" )]
        public CCI Cci { get; set; }

        /// <summary>
        /// 趋向指标(威尔斯·威尔德)
        /// </summary>
        [DataMember( Name = "Dmi" )]
        public DMI Dmi { get; set; }

        /// <summary>
        /// 轨道线
        /// </summary>
        [DataMember( Name = "Ene" )]
        public ENE Ene { get; set; }

        /// <summary>
        /// 慢速随机指标(乔治·莱恩)
        /// </summary>
        [DataMember( Name = "Kd" )]
        public KD Kd { get; set; }

        /// <summary>
        /// 均线
        /// </summary>
        [DataMember( Name = "Ma" )]
        public MA Ma { get; set; }

        /// <summary>
        /// 指数平滑移动平均线(查拉尔德·阿佩尔)
        /// </summary>
        [DataMember( Name = "Macd" )]
        public MACD Macd { get; set; }

        /// <summary>
        /// 当期收盘价
        /// </summary>
        [DataMember( Name = "Close" )]
        public decimal Close { get; set; }
    }
}