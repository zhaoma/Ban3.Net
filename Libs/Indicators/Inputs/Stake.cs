/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（赌注策略）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace  Ban3.Infrastructures.Indicators.Inputs
{
    /// <summary>
    /// 赌注策略（）
    /// 最多买多少钱；多少股
    /// </summary>
    public class Stake
    {
        /// <summary>
        /// 最大额度
        /// </summary>
        public decimal MaxAmount { get; set; }

        /// <summary>
        /// 最大数量
        /// </summary>
        public decimal MaxVolume { get; set; }

        /// <summary>
        /// 最小额度
        /// </summary>
        public decimal MinAmount { get; set; }

        /// <summary>
        /// 最小数量
        /// </summary>
        public decimal MinVolume { get; set; }
    }
}