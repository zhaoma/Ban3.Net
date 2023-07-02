﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（最新指标值）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 最新指标值
/// </summary>
public class Latest
{
    /// <summary>
    /// 上一周期指标值
    /// </summary>
    [JsonProperty("prev", NullValueHandling = NullValueHandling.Ignore)]
    public PointOfTime? Prev { get; set; }

    /// <summary>
    /// 当前周期指标值
    /// </summary>
    [JsonProperty("current", NullValueHandling = NullValueHandling.Ignore)]
    public PointOfTime? Current { get; set; }

    public List<string> Features()
    {
        var result = new List<string>();

        if (Current?.Amount != null)
            result.AddRange(Current.Amount.Features());

        if (Current?.Bias != null)
            result.AddRange(Current.Bias.Features(Prev?.Bias));

        if (Current?.Cci != null)
            result.AddRange(Current.Cci.Features());

        if (Current?.Dmi != null)
            result.AddRange(Current.Dmi.Features(Prev?.Dmi));

        if (Current?.Ene != null)
            result.AddRange(Current.Ene.Features(Current.Close));

        if (Current?.Kd != null)
            result.AddRange(Current.Kd.Features(Prev?.Kd));

        if (Current?.Ma != null)
            result.AddRange(Current.Ma.Features());

        if (Current?.Macd != null)
            result.AddRange(Current.Macd.Features(Prev?.Macd));

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine(this.ObjToJson());
        Console.WriteLine();
        Console.WriteLine(result.ObjToJson());
        Console.WriteLine();



        return result;
    }
}