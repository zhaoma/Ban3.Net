/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标计算接口申明
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace Ban3.Infrastructures.Indicators.Interfaces
{
    /// <summary>
    /// 指标计算接口申明
    /// </summary>
    public interface IIndicatorFormula
    {
        /// <summary>
        /// 修补计算
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="prices"></param>
        void CalculateLastValues(string stockCode, List<Indicators.Inputs.Price> prices);

        /// <summary>
        /// 全数据计算
        /// </summary>
        /// <param name="prices"></param>
        void CalculateAll(List<Indicators.Inputs.Price> prices);
    }
}