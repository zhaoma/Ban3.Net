/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（筛选条件）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace  Ban3.Infrastructures.Indicators.Inputs
{
    /// <summary>
    /// 筛选条件
    /// </summary>
    public class ConditionParttern
    {
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 分析周期（日/周/月）
        /// </summary>
        public Enums.StockAnalysisCycle Cycle { get; set; } = Enums.StockAnalysisCycle.DAILY;

        /// <summary>
        /// 条件组
        /// </summary>
        public List<Condition> Conditions { get; set; }

        /// <summary>
        /// 标识（RedisSetKey）
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 多票筛选结果（存入Set）
        /// </summary>
        public List<string> Output { get; set; }

        /// <summary>
        /// 单票筛选结果
        /// </summary>
        public bool IsMatch { get; set; }
    }
}