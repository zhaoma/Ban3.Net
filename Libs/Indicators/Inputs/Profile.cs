/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（投资策略）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Indicators.Outputs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
        public Profile() {}

        public Profile(
            string identity, 
            string subject,
            Func<StockSets, bool> buyingJudge,
            Func<StockSets, bool> sellingJudge,
            bool persistence = false,
            bool isDefault = false)
        {
            Identity=identity;
            Subject = subject;
            BuyingJudge =  buyingJudge;
            SellingJudge = sellingJudge;
            Persistence=persistence;
            IsDefault=isDefault;
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
        public Func<StockSets, bool>? BuyingJudge { get; set; }

        /// <summary>
        /// 排序条件
        /// ParamA 与 Order
        /// </summary>
        public List<Condition>? OrderConditions { get; set; }

        /// <summary>
        /// 卖出条件
        /// </summary>
        public Func<StockSets, bool>? SellingJudge { get; set; }

        /// <summary>
        /// 发掘条数
        /// </summary>
        public int DigRecordCount { get; set; }

        public bool Persistence { get; set; }

        public bool IsDefault { get; set; }
    }
}