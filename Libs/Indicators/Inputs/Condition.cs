/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（筛选条件）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Enums = Ban3.Infrastructures.Indicators.Enums;

namespace  Ban3.Infrastructures.Indicators.Inputs
{
    /// <summary>
    /// 筛选条件
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// 条件左侧类型
        /// 枚举 变量/常量/价格
        /// </summary>
        public Enums.ConditionParamType ParamAis { get; set; }

        /// <summary>
        /// 运算符
        /// </summary>
        public Enums.ConditionSymbol Symbol { get; set; }

        /// <summary>
        /// 条件右侧类型
        /// 枚举 变量/常量/价格
        /// </summary>
        public Enums.ConditionParamType ParamBis { get; set; }

        /// <summary>
        /// 右侧静态取值
        /// </summary>
        public decimal ValueB { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 排序方式（默认增序）
        /// </summary>
        public bool Desc { get; set; }
    }
}