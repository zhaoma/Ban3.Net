using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Common.Contracts.Servers
{
    public class Sina
    {
        /// <summary>
        /// 分红/配股
        /// </summary>
        public static string UrlForEvents( string code )
            => $"http://money.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/{code}.phtml";

        /// <summary>
        /// 解禁信息
        /// </summary>
        public static string UrlForLifts( string code )
            => $"http://vip.stock.finance.sina.com.cn/q/go.php/vInvestConsult/kind/xsjj/index.phtml?symbol={code}";
    }
}