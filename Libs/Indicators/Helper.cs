using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Indicators
{
    public static class Helper
    {
        public static decimal ToDecimal(this object strValue, decimal defValue = 0)
        {
            decimal.TryParse(strValue.ToString(), out var def);
            return def == 0 ? defValue : def;
        }


        /// <summary>
        /// 相同日期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="inVal"></param>
        /// <returns></returns>
        public static bool DateEqual(this DateTime dt, DateTime inVal) => inVal.ToString("yyyyMMdd") == dt.ToString("yyyyMMdd");

    }
}
