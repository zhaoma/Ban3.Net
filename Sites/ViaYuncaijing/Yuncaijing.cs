using System;
using System.Collections.Generic;
using System.Text;

using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.Common.Contracts.Servers
{
    public class Yuncaijing
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string UrlForOneIcon( string code )
        {
            return $"https://www.yuncaijing.com/quote/{code.GetStockPrefix()}{code}.html";
        }
    }
}