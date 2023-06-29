/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（投资策略）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Indicators.Inputs
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
        [JsonProperty("identity", NullValueHandling = NullValueHandling.Ignore)]
        public string Identity { get; set; } = string.Empty;

        /// <summary>
        /// 主题
        /// </summary>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 投资限制（标的与投入方式）
        /// </summary>
        [JsonProperty("investorLimit", NullValueHandling = NullValueHandling.Ignore)]
        public Limit? InvestorLimit { get; set; }

        /// <summary>
        /// 买入条件
        /// </summary>
        [JsonProperty("buyingCondition", NullValueHandling = NullValueHandling.Ignore)]
        public ProfileCondition? BuyingCondition { get; set; }

        /// <summary>
        /// 排序条件
        /// ParamA 与 Order
        /// </summary>
        [JsonProperty("orderConditions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Condition>? OrderConditions { get; set; }

        /// <summary>
        /// 卖出条件
        /// </summary>
        [JsonProperty("sellingCondition", NullValueHandling = NullValueHandling.Ignore)]
        public ProfileCondition? SellingCondition { get; set; }

        /// <summary>
        /// 发掘条数
        /// </summary>
        [JsonProperty("digRecordCount", NullValueHandling = NullValueHandling.Ignore)]
        public int DigRecordCount { get; set; }

        [JsonProperty("persistence", NullValueHandling = NullValueHandling.Ignore)]
        public bool Persistence { get; set; }

        [JsonProperty("isDefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDefault { get; set; }

        /// 
        public bool MatchBuying(StockSets qs)
            => BuyingCondition != null && BuyingCondition.Match(qs);

        /// 
        public bool MatchSelling(StockSets qs)
            => SellingCondition != null && SellingCondition.Match(qs);
    }
}