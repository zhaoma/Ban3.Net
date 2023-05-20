/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            股东类型
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using System.Linq;

namespace Ban3.Productions.Casino.Contracts.Enums
{
    /// <summary>
    /// 股东类型
    /// </summary>
    public class StockHolderType
    {
        /// <summary>
        /// 股东类型字典
        /// </summary>
        public static Dictionary<string, int> Values => new Dictionary<string, int>
        {
            {"其它", 1},
            {"个人", 2},
            {"基金", 3},
            {"投资公司", 4},
            {"券商", 5},
            {"保险", 6},
            {"社保", 7},
            {"信托", 8},
            {"集合理财计划", 9},
            {"企业年金", 10},
            {"QFII", 11},
            {"财务公司", 12},
            {"金融", 13},
            {"基本养老基金", 14},
            {"高校", 15}
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetKey(int val)
        {
            if (Values.ContainsValue(val))
            {
                return Values.First(o => o.Value == val).Key;
            }

            return "-";
        }
    }
}
