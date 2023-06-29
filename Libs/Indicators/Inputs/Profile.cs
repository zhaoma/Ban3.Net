/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（投资策略）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;

namespace  Ban3.Infrastructures.Indicators.Inputs
{
    /// <summary>
    /// 投资策略
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public Profile()
        {
        }

        public Profile(
            string identity,
            string subject,
            ProfileCondition buyingCondition,
            ProfileCondition sellingCondition,
            bool persistence = false,
            bool isDefault = false)
        {
            Identity = identity;
            Subject = subject;
            BuyingCondition = buyingCondition;
            SellingCondition = sellingCondition;
            Persistence = persistence;
            IsDefault = isDefault;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Identity { get; set; } = string.Empty;

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 投资限制（标的与投入方式）
        /// </summary>
        public Limit? InvestorLimit { get; set; }

        /// <summary>
        /// 买入条件
        /// </summary>
        public ProfileCondition? BuyingCondition { get; set; }

        /// <summary>
        /// 排序条件
        /// ParamA 与 Order
        /// </summary>
        public List<Condition>? OrderConditions { get; set; }

        /// <summary>
        /// 卖出条件
        /// </summary>
        public ProfileCondition? SellingCondition { get; set; }

        /// <summary>
        /// 发掘条数
        /// </summary>
        public int DigRecordCount { get; set; }

        public bool Persistence { get; set; }

        public bool IsDefault { get; set; }

        /// 
        public bool MatchBuying(StockSets qs)
            => BuyingCondition != null && BuyingCondition.Match(qs);

        /// 
        public bool MatchSelling(StockSets qs)
            => SellingCondition != null && SellingCondition.Match(qs);
    }
}