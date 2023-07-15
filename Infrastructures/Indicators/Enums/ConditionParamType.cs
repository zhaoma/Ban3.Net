/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            条件参数取值
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Infrastructures.Indicators.Enums;

/// <summary>
/// 条件参数取值
/// </summary>
public enum ConditionParamType
{
    /// <summary>
    /// 常量
    /// </summary>
    [Description("常量")]
    CONSTANT = 3,

    /// <summary>
    /// AMOUNT 5
    /// </summary>
    [Description("AMOUNT短期")]
    AMOUNT5 = 11,

    /// <summary>
    /// AMOUNT 10
    /// </summary>
    [Description("AMOUNT长期")]
    AMOUNT10 = 12,

    /// <summary>
    /// 乖离率
    /// </summary>
    [Description("乖离率")]
    BIAS = 21,

    /// <summary>
    /// 乖离率均线
    /// </summary>
    [Description("乖离率均线")]
    BIASMA = 22,

    /// <summary>
    /// 顺势指标
    /// </summary>
    [Description("顺势指标CCI")]
    CCI = 31,

    /// <summary>
    /// DMI趋向指标 多头指标
    /// </summary>
    [Description("DMI PDI")]
    DMIPDI = 41,

    /// <summary>
    /// DMI趋向指标 空头指标
    /// </summary>
    [Description("DMI MDI")]
    DMIMDI = 42,

    /// <summary>
    /// DMI趋向指标 ADX
    /// </summary>
    [Description("DMI ADX")]
    DMIADX = 43,

    /// <summary>
    /// DMI趋向指标 ADXR
    /// </summary>
    [Description("DMI ADXR")]
    DMIADXR = 44,

    /// <summary>
    /// 上轨
    /// </summary>
    [Description("ENE UPPER")]
    ENEUPPER = 51,

    /// <summary>
    /// 中轨
    /// </summary>
    [Description("ENE")]
    ENE = 52,

    /// <summary>
    /// ENE 下轨
    /// </summary>
    [Description("ENE LOWER")]
    ENELOWER = 53,

    /// <summary>
    /// KD K
    /// </summary>
    [Description("KD K")]
    KDK = 61,

    /// <summary>
    /// KD D
    /// </summary>
    [Description("KD D")]
    KDD = 62,

    /// <summary>
    /// MA 5
    /// </summary>
    [Description("MA 5")]
    MA5 = 71,

    /// <summary>
    /// MA 10
    /// </summary>
    [Description("MA 10")]
    MA10 = 72,

    /// <summary>
    /// MA 20
    /// </summary>
    [Description("MA 20")]
    MA20 = 73,

    /// <summary>
    /// MA 30
    /// </summary>
    [Description("MA 30")]
    MA30 = 74,

    /// <summary>
    /// MACD DIF
    /// </summary>
    [Description("MACD DIF")]
    MACDDIF = 81,

    /// <summary>
    /// MACD DEA
    /// </summary>
    [Description("MACD DEA")]
    MACDDEA = 82,

    /// <summary>
    /// MACD
    /// </summary>
    [Description("MACD")]
    MACD = 83,


    /// <summary>
    /// 价格
    /// </summary>
    [Description("价格")]
    Price = 101,
    /// <summary>
    /// 成交额
    /// </summary>
    [Description("成交额")]
    Amount = 102,
    /// <summary>
    /// 流通股本
    /// </summary>
    [Description("流通股本")]
    NegotiableCapital = 103,
    /// <summary>
    /// 总股本
    /// </summary>
    [Description("总股本")]
    GeneralCapital = 104,
    /// <summary>
    /// 净资产
    /// </summary>
    [Description("净资产")]
    Equity = 105,
    /// <summary>
    /// 市净率
    /// </summary>
    [Description("市净率")]
    EquityRatio = 106,
    /// <summary>
    /// 市盈率
    /// </summary>
    [Description("市盈率")]
    EarningsRatio = 107,
    /// <summary>
    /// 负债率
    /// </summary>
    [Description("负债率")]
    DebtsRatio = 108
}