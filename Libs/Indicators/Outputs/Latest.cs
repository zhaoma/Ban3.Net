/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（最新指标值）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 最新指标值
    /// </summary>
    public class Latest
    {
        /// <summary>
        /// 上一周期指标值
        /// </summary>
        public PointOfTime? Prev { get; set; }

        /// <summary>
        /// 当前周期指标值
        /// </summary>
        public PointOfTime? Current { get; set; }

        public List<string> Features()
        {
            var result = new List<string>();

            if (Current?.Amount != null)
                result.AddRange(Current.Amount.Features());

            if (Current?.Bias != null)
                result.AddRange(Current.Bias.Features(Prev?.Bias));

            if (Current?.Cci != null)
                result.AddRange(Current.Cci.Features());

            if (Current?.Dmi != null)
                result.AddRange(Current.Dmi.Features(Prev?.Dmi));

            if (Current?.Ene != null)
                result.AddRange(Current.Ene.Features(Current.Close));

            if (Current?.Kd != null)
                result.AddRange(Current.Kd.Features(Prev?.Kd));

            if (Current?.Ma != null)
                result.AddRange(Current.Ma.Features());

            if (Current?.Macd != null)
                result.AddRange(Current.Macd.Features(Prev?.Macd));

            return result;
        }
    }
}