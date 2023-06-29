/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            股东类型
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace Ban3.Infrastructures.Indicators.Enums;

/// <summary>
/// 股东类型
/// </summary>
public class StockHolderType
{
    /// <summary>
    /// 股东类型字典
    /// </summary>
    public static Dictionary< int, string> Values => new Dictionary<int, string>
        {
            {1,"其它"},
            {2,"个人"},
            {3,"基金"},
            {4,"投资公司"},
            {5,"券商"},
            {6,"保险"},
            {7,"社保"},
            {8,"信托"},
            {9,"集合理财计划"},
            {10,"企业年金"},
            {11,"QFII"},
            {12,"财务公司"},
            {13,"金融"},
            {14,"基本养老基金"},
            {15,"高校"}
        };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string GetKey(int val)
    => Values.TryGetValue(val, out var s) ? s : "-";
}