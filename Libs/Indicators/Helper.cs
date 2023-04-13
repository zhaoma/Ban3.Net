using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ban3.Infrastructures.Indicators
{
    public static class Helper
    {
        static readonly ILog _logger = LogManager.GetLogger(typeof(Helper));

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static StockGroup GetStockGroup(this string code)
        {
            if (code.Length < 6)
                return (StockGroup)0;
            string str = code.Substring(0, 3);
            if (str == "000")
                return StockGroup.SZA;
            if (str == "002" || str == "003")
                return StockGroup.SZZ;
            if (str == "300" || str == "301")
                return StockGroup.SZC;
            return str == "688" ? StockGroup.SHK : StockGroup.SHA;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetStockPrefix(this string code)
        {
            switch (code.GetStockGroup())
            {
                case StockGroup.SZA:
                case StockGroup.SZZ:
                case StockGroup.SZC:
                    return "sz";
                default:
                    return "sh";
            }
        }

        public static List<Latest> ConvertToLatestList(this LineOfPoint line)
        {
            List<Latest> list = line.EndPoints.Select((PointOfTime o) => new Latest
            {
                Current = o
            }).ToList();
            for (int i = 1; i < list.Count; i++)
            {
                list[i].Prev = list[i - 1].Current;
            }

            return list;
        }

        public static bool JudgeOneIndex(this Latest latest, ConditionParttern conditionParttern)
        {
            return conditionParttern.Conditions.All((Condition o) => latest.JudgeOneIndex(o));
        }

        static bool JudgeOneIndex(this Latest latest, Condition condition)
        {
            decimal? value = latest.Current.GetValue(condition.ParamAis, condition.ValueB);
            decimal? value2 = latest.Current.GetValue(condition.ParamBis, condition.ValueB);
            if (!value.HasValue || !value2.HasValue)
            {
                return false;
            }

            decimal? value3 = latest.Prev.GetValue(condition.ParamAis, condition.ValueB);
            decimal? value4 = latest.Prev.GetValue(condition.ParamBis, condition.ValueB);
            switch (condition.Symbol)
            {
                case ConditionSymbol.GT:
                    return value > value2;
                case ConditionSymbol.GE:
                    return value >= value2;
                case ConditionSymbol.EQ:
                    return value == value2;
                case ConditionSymbol.LT:
                    return value < value2;
                case ConditionSymbol.LE:
                    return value <= value2;
                case ConditionSymbol.UC:
                    if (!value3.HasValue || !value4.HasValue)
                    {
                        return false;
                    }

                    if (value3 <= value4)
                    {
                        return value >= value2;
                    }

                    return false;
                case ConditionSymbol.DC:
                    if (!value3.HasValue || !value4.HasValue)
                    {
                        return false;
                    }

                    if (value3 >= value4)
                    {
                        return value <= value2;
                    }

                    return false;
                default:
                    return false;
            }
        }

        static decimal? GetValue(
            this PointOfTime endPoint,
            ConditionParamType pt,
            decimal val,
            StockInfo stockInfo = null)
        {
            decimal? result = null;
            try
            {
                if (pt <= ConditionParamType.BIASMA)
                {
                    if (pt <= ConditionParamType.AMOUNT5)
                    {
                        switch (pt)
                        {
                            case ConditionParamType.CONSTANT:
                                return val;
                            case ConditionParamType.AMOUNT5:
                                if (endPoint.Amount == null)
                                {
                                    return result;
                                }

                                if (endPoint.Amount.RefAmounts == null)
                                {
                                    return result;
                                }

                                if (endPoint.Amount.RefAmounts.Any())
                                {
                                    return endPoint.Amount.RefAmounts.FirstOrDefault((LineWithValue o) => o.Days == 5)?.Ref;
                                }

                                return result;
                            default:
                                return result;
                        }
                    }

                    switch (pt)
                    {
                        case ConditionParamType.AMOUNT10:
                            if (endPoint.Amount != null)
                            {
                                if (endPoint.Amount.RefAmounts != null)
                                {
                                    if (endPoint.Amount.RefAmounts.Any())
                                    {
                                        return endPoint.Amount.RefAmounts.FirstOrDefault((LineWithValue o) => o.Days == 10)?.Ref;
                                    }

                                    return result;
                                }

                                return result;
                            }

                            return result;
                        case ConditionParamType.BIAS:
                            if (endPoint.Bias != null)
                            {
                                if (endPoint.Bias.RefBIAS.HasValue)
                                {
                                    return endPoint.Bias.RefBIAS.Value;
                                }

                                return result;
                            }

                            return result;
                        case ConditionParamType.BIASMA:
                            if (endPoint.Bias != null)
                            {
                                if (endPoint.Bias.RefBIASMA.HasValue)
                                {
                                    return endPoint.Bias.RefBIASMA.Value;
                                }

                                return result;
                            }

                            return result;
                        default:
                            return result;
                    }
                }

                if (pt <= ConditionParamType.KDK)
                {
                    switch (pt)
                    {
                        case ConditionParamType.CCI:
                            if (endPoint.Cci == null)
                            {
                                return result;
                            }

                            if (endPoint.Cci.RefCCI.HasValue)
                            {
                                return endPoint.Cci.RefCCI.Value;
                            }

                            return result;
                        case ConditionParamType.DMIPDI:
                            if (endPoint.Dmi == null)
                            {
                                return result;
                            }

                            if (endPoint.Dmi.RefPDI.HasValue)
                            {
                                return endPoint.Dmi.RefPDI.Value;
                            }

                            return result;
                        case ConditionParamType.DMIMDI:
                            if (endPoint.Dmi == null)
                            {
                                return result;
                            }

                            if (endPoint.Dmi.RefMDI.HasValue)
                            {
                                return endPoint.Dmi.RefMDI.Value;
                            }

                            return result;
                        case ConditionParamType.DMIADX:
                            if (endPoint.Dmi == null)
                            {
                                return result;
                            }

                            if (endPoint.Dmi.RefADX.HasValue)
                            {
                                return endPoint.Dmi.RefADX.Value;
                            }

                            return result;
                        case ConditionParamType.DMIADXR:
                            if (endPoint.Dmi == null)
                            {
                                return result;
                            }

                            if (endPoint.Dmi.RefADXR.HasValue)
                            {
                                return endPoint.Dmi.RefADXR.Value;
                            }

                            return result;
                        case ConditionParamType.ENEUPPER:
                            if (endPoint.Ene == null)
                            {
                                return result;
                            }

                            if (endPoint.Ene.RefUPPER.HasValue)
                            {
                                return endPoint.Ene.RefUPPER.Value;
                            }

                            return result;
                        case ConditionParamType.ENE:
                            if (endPoint.Ene == null)
                            {
                                return result;
                            }

                            if (endPoint.Ene.RefENE.HasValue)
                            {
                                return endPoint.Ene.RefENE.Value;
                            }

                            return result;
                        case ConditionParamType.ENELOWER:
                            if (endPoint.Ene == null)
                            {
                                return result;
                            }

                            if (endPoint.Ene.RefLOWER.HasValue)
                            {
                                return endPoint.Ene.RefLOWER.Value;
                            }

                            return result;
                        case ConditionParamType.KDK:
                            if (endPoint.Kd == null)
                            {
                                return result;
                            }

                            if (endPoint.Kd.RefK.HasValue)
                            {
                                return endPoint.Kd.RefK.Value;
                            }

                            return result;
                        default:
                            return result;
                        case (ConditionParamType)45:
                        case (ConditionParamType)46:
                        case (ConditionParamType)47:
                        case (ConditionParamType)48:
                        case (ConditionParamType)49:
                        case (ConditionParamType)50:
                            return result;
                    }
                }

                switch (pt)
                {
                    case ConditionParamType.KDD:
                        if (endPoint.Kd != null)
                        {
                            if (endPoint.Kd.RefD.HasValue)
                            {
                                return endPoint.Kd.RefD.Value;
                            }

                            return result;
                        }

                        return result;
                    case ConditionParamType.MA5:
                        if (endPoint.Ma != null)
                        {
                            if (endPoint.Ma.RefPrices != null)
                            {
                                if (endPoint.Ma.RefPrices.Any())
                                {
                                    return endPoint.Ma.RefPrices.FirstOrDefault((LineWithValue o) => o.Days == 5)?.Ref;
                                }

                                return result;
                            }

                            return result;
                        }

                        return result;
                    case ConditionParamType.MA10:
                        if (endPoint.Ma != null)
                        {
                            if (endPoint.Ma.RefPrices != null)
                            {
                                if (endPoint.Ma.RefPrices.Any())
                                {
                                    return endPoint.Ma.RefPrices.FirstOrDefault((LineWithValue o) => o.Days == 10)?.Ref;
                                }

                                return result;
                            }

                            return result;
                        }

                        return result;
                    case ConditionParamType.MA20:
                        if (endPoint.Ma != null)
                        {
                            if (endPoint.Ma.RefPrices != null)
                            {
                                if (endPoint.Ma.RefPrices.Any())
                                {
                                    return endPoint.Ma.RefPrices.FirstOrDefault((LineWithValue o) => o.Days == 20)?.Ref;
                                }

                                return result;
                            }

                            return result;
                        }

                        return result;
                    case ConditionParamType.MA30:
                        if (endPoint.Ma != null)
                        {
                            if (endPoint.Ma.RefPrices != null)
                            {
                                if (endPoint.Ma.RefPrices.Any())
                                {
                                    return endPoint.Ma.RefPrices.FirstOrDefault((LineWithValue o) => o.Days == 30)?.Ref;
                                }

                                return result;
                            }

                            return result;
                        }

                        return result;
                    case ConditionParamType.MACDDIF:
                        if (endPoint.Macd != null)
                        {
                            return endPoint.Macd.RefDIF;
                        }

                        return result;
                    case ConditionParamType.MACDDEA:
                        if (endPoint.Macd != null)
                        {
                            return endPoint.Macd.RefDEA;
                        }

                        return result;
                    case ConditionParamType.MACD:
                        if (endPoint.Macd != null)
                        {
                            return endPoint.Macd.RefMACD;
                        }

                        return result;
                    case ConditionParamType.Price:
                        if (stockInfo != null)
                        {
                            return stockInfo.CurrentClose;
                        }

                        return result;
                    case ConditionParamType.Amount:
                        if (stockInfo != null)
                        {
                            return stockInfo.Amount;
                        }

                        return result;
                    case ConditionParamType.NegotiableCapital:
                        if (stockInfo != null)
                        {
                            return stockInfo.NegotiableCapital;
                        }

                        return result;
                    case ConditionParamType.GeneralCapital:
                        if (stockInfo != null)
                        {
                            return stockInfo.GeneralCapital;
                        }

                        return result;
                    case ConditionParamType.Equity:
                        if (stockInfo != null)
                        {
                            return stockInfo.Equity;
                        }

                        return result;
                    case ConditionParamType.EquityRatio:
                        if (stockInfo != null)
                        {
                            return stockInfo.EquityRatio;
                        }

                        return result;
                    case ConditionParamType.EarningsRatio:
                        if (stockInfo != null)
                        {
                            return stockInfo.EarningsRatio;
                        }

                        return result;
                    case ConditionParamType.DebtsRatio:
                        if (stockInfo != null)
                        {
                            return stockInfo.DebtsRatio;
                        }

                        return result;
                    default:
                        return result;
                    case (ConditionParamType)75:
                    case (ConditionParamType)76:
                    case (ConditionParamType)77:
                    case (ConditionParamType)78:
                    case (ConditionParamType)79:
                    case (ConditionParamType)80:
                        return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}
