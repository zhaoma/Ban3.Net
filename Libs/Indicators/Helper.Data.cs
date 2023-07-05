/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System.Collections.Generic;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Styles;
using System.Linq;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;

namespace Ban3.Infrastructures.Indicators;

public static partial class Helper
{
    /// <summary>
    /// LineOfPoint 保存
    /// </summary>
    /// <param name="line"></param>
    /// <param name="saveName"></param>
    /// <returns></returns>
    public static LineOfPoint? LoadLineOfPoint(string key)
        => key.LoadEntity<LineOfPoint>();

    /// <summary>
    /// StockSets 保存
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="saveName"></param>
    /// <returns></returns>
    public static List<StockSets>? Save(this List<StockSets>? sets, string saveName)
        => sets.SaveEntities(saveName);

    public static List<StockSets>? LoadSets(this string code)
        =>  code.LoadEntities<StockSets>();

    public static List<string>? GetSetKeys(this List<StockSets>? sets, string tradeDate)
        => sets.Last(o => o.MarkTime.ToYmd().Equals(tradeDate))?
        .SetKeys?.ToList();
    
    #region indicators

    static Series[] AMOUNT(this LineOfPoint indicatorValue, List<Price> prices, int? index, out List<string> legendData)
    {
        var result = new List<Series>
        {
            SeriesType.Bar.CreateSeries(
                "AMOUNT",
                prices
                    .Select(o => o.Amount).ToList(),
                index)
        };

        var amount = new Infrastructures.Indicators.Formulas.Specials.AMOUNT();
        foreach (var line in amount.Details!)
        {
            var color = Infrastructures.Charts.Helper.Red;
            switch (line.Days)
            {
                case 5:
                    color = Infrastructures.Charts.Helper.Yellow;
                    break;
                case 10:
                    color = Infrastructures.Charts.Helper.Purple;
                    break;
            }
            var s = SeriesType.Line.CreateSeries(
                $"AMOUNT.{line.Days}",
                indicatorValue.EndPoints?
                    .Select(o => o.Amount!.RefAmounts.FindLast(x => x.Days == line.Days)?.Ref)
                    .ToList(),
                index, color);
            result.Add(s);
        }

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] BIAS(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new[]
        {
            SeriesType.Line.CreateSeries(
                "BIAS",
                indicatorValue.EndPoints?
                    .Select(o => o.Bias!.RefBIAS).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "BIAS.MA",
                indicatorValue.EndPoints?
                    .Select(o => o.Bias!.RefBIASMA).ToList(),
                index,Infrastructures.Charts.Helper.Yellow)
        };

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series CCI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = SeriesType.Line.CreateSeries(
            "CCI",
            indicatorValue.EndPoints?
                .Select(o => o.Cci!.RefCCI).ToList(),
            index);

        result.MarkLine = new GeneralMark
        {
            Symbol = Symbol.None.ToString().ToLower(),
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Red },
            Data = new()
            {
                new GeneralData {YAxis = 200},
                new GeneralData {YAxis = 100},
                new GeneralData {YAxis = -200},
            }
        };

        legendData = new List<string> { "CCI" };

        return result;
    }

    static Series[] DMI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var adx = SeriesType.Line.CreateSeries(
            "DMI.ADX",
            indicatorValue.EndPoints?
                .Select(o => o.Dmi!.RefADX).ToList(),
            index, Infrastructures.Charts.Helper.Purple);

        adx.MarkLine = new GeneralMark
        {
            Symbol = Symbol.None.ToString().ToLower(),
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Purple },
            Data = new()
            {
                new GeneralData {YAxis = 80}
            }
        };

        var result = new[]
        {
            SeriesType.Line.CreateSeries(
                "DMI.PDI",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi!.RefPDI).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.MDI",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi!.RefMDI).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),
            adx,
            SeriesType.Line.CreateSeries(
                "DMI.ADXR",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi!.RefADXR).ToList(),
                index,Infrastructures.Charts.Helper.Green)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] ENE(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var upper = SeriesType.Line.CreateSeries(
            "ENE.Upper",
            indicatorValue.EndPoints?
                .Select(o => o.Ene!.RefUPPER).ToList(),
            index, Infrastructures.Charts.Helper.Red, 2);

        upper.LineStyle!.Type = BorderType.Dotted;

        var ene = SeriesType.Line.CreateSeries(
            "ENE",
            indicatorValue.EndPoints?
                .Select(o => o.Ene!.RefENE).ToList(),
            index, Infrastructures.Charts.Helper.Purple, 2);

        ene.LineStyle!.Type = BorderType.Dotted;

        var lower = SeriesType.Line.CreateSeries(
            "ENE.Lower",
            indicatorValue.EndPoints?
                .Select(o => o.Ene!.RefLOWER).ToList(),
            index, Infrastructures.Charts.Helper.Yellow, 2);

        lower.LineStyle!.Type = BorderType.Dotted;

        var result = new[]
        {
            upper,ene,lower
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }


    static Series[] KD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var k = SeriesType.Line.CreateSeries(
            "KD.K",
            indicatorValue.EndPoints?
                .Select(o => o.Kd!.RefK).ToList(),
            index);

        k.MarkLine = new GeneralMark
        {
            Symbol = Symbol.None.ToString().ToLower(),
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Red },
            Data = new()
            {
                new GeneralData {YAxis = 80},
                new GeneralData {YAxis = 10},
            }
        };

        var result = new[]
        {
            k,
            SeriesType.Line.CreateSeries(
                "KD.D",
                indicatorValue.EndPoints?
                    .Select(o => o.Kd!.RefD).ToList(),
                index,Infrastructures.Charts.Helper.Yellow)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] MA(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new List<Series>();

        var ma = new Infrastructures.Indicators.Formulas.Specials.MA();
        foreach (var line in ma.Details)
        {
            var color = Infrastructures.Charts.Helper.Red;
            switch (line.Days)
            {
                case 10:
                    color = Infrastructures.Charts.Helper.Yellow;
                    break;
                case 20:
                    color = Infrastructures.Charts.Helper.Purple;
                    break;
                case 30:
                    color = Infrastructures.Charts.Helper.Green;
                    break;
                case 60:
                    color = Infrastructures.Charts.Helper.Gray;
                    break;
            }


            var s = SeriesType.Line.CreateSeries(
                    $"MA.{line.Days}",
                    indicatorValue.EndPoints?
                        .Select(o => o.Ma!.RefPrices.FindLast(x => x.Days == line.Days)?.Ref).ToList(),
                    index, color);
            result.Add(s);
        }

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] MACD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new[]
        {
            SeriesType.Bar.CreateSeries(
                "MACD",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd!.RefMACD).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DEA",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd!.RefDEA).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),
            SeriesType.Line.CreateSeries(
                "MACD.DIF",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd!.RefDIF).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }
    #endregion

    public static Diagram Save(this Diagram diagram, string key)
        => diagram.SaveEntity(_ => key);

    public static Diagram LoadDiagram(this string key)
        => key.LoadEntity<Diagram>()!;


}