/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（完整）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Formulas.Specials;
using Ban3.Infrastructures.Indicators.Outputs;

namespace Ban3.Infrastructures.Indicators.Formulas;

/// <summary>
/// 完整指标
/// </summary>
public class Full
    : Communal
{
    public LineOfPoint Result { get; set; } = new();

    public void Calculate(List<Inputs.Price> prices,string code)
    {
        if (!prices.Any())
        {
            Logger.Error("prices is empty.");
            return;
        }

        Result = new LineOfPoint
        {
            EndPoints = prices
                .Select(o => new PointOfTime
                {
                    MarkTime = o.MarkTime,
                    Close = o.CurrentClose!.Value,
                    Amount = new Outputs.Values.AMOUNT
                    {
                        MarkTime = o.MarkTime,
                        RefAmounts = new List<LineWithValue>()
                    },
                    Bias = new Outputs.Values.BIAS { MarkTime = o.MarkTime },
                    Cci = new Outputs.Values.CCI
                    {
                        MarkTime = o.MarkTime,
                        RefTYP = Math.Round((o.CurrentHigh!.Value + o.CurrentLow!.Value + o.CurrentClose.Value) / 3, 3)
                    },
                    Dmi = new Outputs.Values.DMI
                    {
                        MarkTime = o.MarkTime,
                        RefADX = 0M,
                        RefADXR = 0M,
                        RefPDI = 0M,
                        RefMDI = 0M
                    },
                    Ene = new Outputs.Values.ENE { MarkTime = o.MarkTime },
                    Kd = new Outputs.Values.KD
                    {
                        MarkTime = o.MarkTime,
                        RefLLV = o.CurrentLow,
                        RefHHV = o.CurrentHigh
                    },
                    Ma = new Outputs.Values.MA { MarkTime = o.MarkTime, RefPrices = new List<LineWithValue>() },
                    Macd = new Outputs.Values.MACD { MarkTime = o.MarkTime }
                })
                .ToList()
        };

        var amount = new AMOUNT();
        var bias = new BIAS();
        var cci = new CCI();
        var dmi = new DMI();
        var ene = new ENE();
        var kd = new KD();
        var ma = new MA();
        var macd = new MACD();

        var middles = prices.Select(o =>
            new[]
            {
                o.CurrentHigh!.Value,
                o.CurrentLow!.Value,
                o.CurrentClose!.Value,
                0,
                0,
                Math.Abs(o.CurrentHigh.Value - o.CurrentLow.Value)
            }).ToList();

        var emaShortYest = 0M;
        var emaLongYest = 0M;
        var deaYest = 0M;

        for (var i = 0; i < prices.Count; i++)
        {
            #region AMOUNT

            try
            {
                foreach (var detail in amount.Details!)
                {
                    if (i >= detail.Days - 1)
                    {
                        if (Result.EndPoints[i].Amount!.RefAmounts.All(o => o.ParamId != detail.ParamId))
                        {
                            Result.EndPoints[i].Amount!.RefAmounts.Add(
                                new LineWithValue
                                {
                                    ParamId = detail.ParamId,
                                    Ref = DescRangeAmountAverage(prices, i, detail.Days),
                                    Days = detail.Days
                                });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region BIAS

            if (i >= bias.N - 1)
            {
                var biasMA = DescRangeCloseAverage(prices, i, bias.N);

                if (biasMA != 0)
                {
                    Result.EndPoints[i].Bias!.RefBIAS =
                        Math.Round((prices[i].CurrentClose!.Value - biasMA) / biasMA * 100M, 3);
                }
            }

            if (i >= bias.N + bias.M - 2)
            {
                var biasSum = 0M;
                for (int j = 0; j < bias.M; j++)
                {
                    if (Result.EndPoints[i - j].Bias!.RefBIAS != null)
                    {
                        biasSum += Result.EndPoints[i - j].Bias!.RefBIAS!.Value;
                    }
                }

                Result.EndPoints[i].Bias!.RefBIASMA = Math.Round(biasSum / bias.M, 3);
            }

            #endregion

            #region CCI

            if (i >= cci.N - 1)
            {
                var rr = new List<decimal>();
                for (int r = i; r > i - cci.N; r--)
                {
                    rr.Add(Result.EndPoints[r].Cci!.RefTYP);
                }

                Result.EndPoints[i].Cci!.RefCCI = AVEDEV(Result.EndPoints[i].Cci!.RefTYP, rr);
            }

            #endregion

            #region DMI

            try
            {
                if (i > 0)
                {
                    Result.EndPoints[i].Dmi!.RefHD = middles[i][0] - middles[i - 1][0];
                    Result.EndPoints[i].Dmi!.RefLD = middles[i - 1][1] - middles[i][1];

                    middles[i][3] =
                        Result.EndPoints[i].Dmi!.RefHD!.Value > 0 && Result.EndPoints[i].Dmi!.RefHD!.Value >
                        Result.EndPoints[i].Dmi!.RefLD!.Value
                            ? Result.EndPoints[i].Dmi!.RefHD!.Value
                            : 0M;
                    middles[i][4] =
                        Result.EndPoints[i].Dmi!.RefLD!.Value > 0 && Result.EndPoints[i].Dmi!.RefLD!.Value >
                        Result.EndPoints[i].Dmi!.RefHD!.Value
                            ? Result.EndPoints[i].Dmi!.RefLD!.Value
                            : 0M;

                    middles[i][5] = Math.Max(middles[i][5], Math.Abs(middles[i][0] - middles[i - 1][2]));
                    middles[i][5] = Math.Max(middles[i][5], Math.Abs(middles[i][1] - middles[i - 1][2]));

                    var dmp = 0M;
                    var dmm = 0M;
                    var mtr = 0M;
                    for (int index = 0; index < dmi.N; index++)
                    {
                        if (index <= i)
                        {
                            var current = Math.Max(0, i - index);

                            mtr += middles[current][5];
                            dmp += middles[current][3];
                            dmm += middles[current][4];
                        }
                    }

                    Result.EndPoints[i].Dmi!.RefMTR = mtr;
                    Result.EndPoints[i].Dmi!.RefDMP = dmp;
                    Result.EndPoints[i].Dmi!.RefDMM = dmm;

                    if (mtr != 0)
                    {
                        Result.EndPoints[i].Dmi!.RefPDI = dmp * 100 / mtr;
                        Result.EndPoints[i].Dmi!.RefMDI = dmm * 100 / mtr;
                    }
                }
                else
                {
                    Result.EndPoints[i].Dmi!.RefHD = 0M; // prices[i].CurrentClose;
                    Result.EndPoints[i].Dmi!.RefLD = 0M; // -prices[i].CurrentOpenEx;
                    Result.EndPoints[i].Dmi!.RefMTR = middles[i][5];
                }

                if (i >= dmi.M - 1)
                {
                    var adx = 0M;
                    for (int r = i; r > i - dmi.M; r--)
                    {
                        adx += Result.EndPoints[r].Dmi!.RefPDI + Result.EndPoints[r].Dmi!.RefMDI == 0M
                            ? 0M
                            : Math.Abs(Result.EndPoints[r].Dmi!.RefMDI!.ToDecimal() -
                                       Result.EndPoints[r].Dmi!.RefPDI!.ToDecimal()) /
                              (Result.EndPoints[r].Dmi!.RefPDI!.ToDecimal() +
                               Result.EndPoints[r].Dmi!.RefMDI!.ToDecimal()) *
                              100M;
                    }

                    Result.EndPoints[i].Dmi!.RefADX = adx / dmi.M;
                }

                if (i >= 2 * dmi.M - 1)
                {
                    Result.EndPoints[i].Dmi!.RefADXR = (Result.EndPoints[i].Dmi!.RefADX!.ToDecimal() +
                                                       Result.EndPoints[i - dmi.M].Dmi!.RefADX!.ToDecimal()) / 2;
                }

                Result.EndPoints[i].Dmi!.RefADX = Math.Round(Result.EndPoints[i].Dmi!.RefADX!.ToDecimal(), 3);
                Result.EndPoints[i].Dmi!.RefADXR = Math.Round(Result.EndPoints[i].Dmi!.RefADXR!.ToDecimal(), 3);
                Result.EndPoints[i].Dmi!.RefHD = Math.Round(Result.EndPoints[i].Dmi!.RefHD!.ToDecimal(), 3);
                Result.EndPoints[i].Dmi!.RefLD = Math.Round(Result.EndPoints[i].Dmi!.RefLD!.ToDecimal(), 3);
                Result.EndPoints[i].Dmi!.RefMDI = Math.Round(Result.EndPoints[i].Dmi!.RefMDI!.ToDecimal(), 3);
                Result.EndPoints[i].Dmi!.RefPDI = Math.Round(Result.EndPoints[i].Dmi!.RefPDI!.ToDecimal(), 3);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region ENE

            if (i >= ene.N - 1)
            {
                var eneMa = DescRangeCloseAverage(prices, i, ene.N);

                Result.EndPoints[i].Ene!.RefUPPER = Math.Round((1 + ene.M1 / 100M) * eneMa, 2);
                Result.EndPoints[i].Ene!.RefLOWER = Math.Round((1 - ene.M2 / 100M) * eneMa, 2);
                Result.EndPoints[i].Ene!.RefENE =
                    Math.Round((Result.EndPoints[i].Ene!.RefUPPER!.Value + Result.EndPoints[i].Ene!.RefLOWER!.Value) / 2,
                        2);
            }

            #endregion

            #region KD

            try
            {
                Result.EndPoints[i].Kd!.RefLLV = LLV(prices, i, kd.N);
                Result.EndPoints[i].Kd!.RefHHV = HHV(prices, i, kd.N);

                if (Result.EndPoints[i].Kd!.RefHHV - Result.EndPoints[i].Kd!.RefLLV != 0)
                {
                    Result.EndPoints[i].Kd!.RefDailyPSV = Math.Round(
                        (prices[i].CurrentClose!.Value - Result.EndPoints[i].Kd!.RefLLV!.Value) * 100M /
                        (Result.EndPoints[i].Kd!.RefHHV!.Value - Result.EndPoints[i].Kd!.RefLLV!.Value), 3);
                }
                else
                {
                    Result.EndPoints[i].Kd!.RefDailyPSV = 0;
                }

                if (i > 0)
                {
                    Result.EndPoints[i].Kd!.RefPSV = EMA(
                        Result.EndPoints[i].Kd!.RefDailyPSV!.Value,
                        Result.EndPoints[i - 1].Kd!.RefPSV!.Value,
                        kd.M);

                    Result.EndPoints[i].Kd!.RefK = EMA(
                        Result.EndPoints[i].Kd!.RefPSV!.Value,
                        Result.EndPoints[i - 1].Kd!.RefK!.Value,
                        kd.M);
                }
                else
                {
                    Result.EndPoints[i].Kd!.RefPSV = Result.EndPoints[i].Kd!.RefDailyPSV;
                    Result.EndPoints[i].Kd!.RefK = Result.EndPoints[i].Kd!.RefDailyPSV;
                }

                if (i >= kd.M - 1)
                {
                    var d = 0M;
                    for (int r = 0; r < kd.M; r++)
                    {
                        d += Result.EndPoints[i - r].Kd!.RefK!.Value;
                    }

                    Result.EndPoints[i].Kd!.RefD = Math.Round(d / kd.M, 3);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Code={code}");
                Logger.Error(ex);
            }

            #endregion

            #region MA

            try
            {
                foreach (var detail in ma.Details)
                {
                    if (i >= detail.Days - 1)
                    {
                        var maMa = DescRangeCloseAverage(prices, i, detail.Days);

                        if (Result.EndPoints[i].Ma!.RefPrices.All(o => o.ParamId != detail.ParamId))
                        {
                            Result.EndPoints[i].Ma!.RefPrices.Add(
                                new LineWithValue
                                {
                                    ParamId = detail.ParamId,
                                    Ref = Math.Round(maMa, 2),
                                    Days = detail.Days
                                });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion

            #region MACD

            try
            {
                #region Calc

                if (i == 0)
                {
                    Result.EndPoints[i].Macd = new Outputs.Values.MACD
                    {
                        MarkTime = prices[i].MarkTime,
                        RefEMAShort = prices[i].CurrentClose!.Value,
                        RefEMALong = prices[i].CurrentClose!.Value
                    };
                }
                else
                {
                    Result.EndPoints[i].Macd = new Outputs.Values.MACD
                    {
                        MarkTime = prices[i].MarkTime,
                        RefEMAShort = EMA(prices[i].CurrentClose!.Value, emaShortYest, macd.SHORT),
                        RefEMALong = EMA(prices[i].CurrentClose!.Value, emaLongYest, macd.LONG)
                    };

                    Result.EndPoints[i].Macd!.RefDIF =
                        Math.Round(Result.EndPoints[i].Macd!.RefEMAShort - Result.EndPoints[i].Macd!.RefEMALong, 3);
                    Result.EndPoints[i].Macd!.RefDEA =
                        Math.Round(
                            deaYest * (macd.MID - 1) / (macd.MID + 1) +
                            Result.EndPoints[i].Macd!.RefDIF * 2 / (macd.MID + 1), 3);
                    Result.EndPoints[i].Macd!.RefMACD =
                        Math.Round(2 * (Result.EndPoints[i].Macd!.RefDIF - Result.EndPoints[i].Macd!.RefDEA), 3);
                }

                emaShortYest = Result.EndPoints[i].Macd!.RefEMAShort;
                emaLongYest = Result.EndPoints[i].Macd!.RefEMALong;
                deaYest = Result.EndPoints[i].Macd!.RefDEA;

                #endregion
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            #endregion
        }
    }
}