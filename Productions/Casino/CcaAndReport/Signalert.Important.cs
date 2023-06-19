using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Productions.Casino.Contracts.Response;
using Helper = Ban3.Infrastructures.Common.Extensions.Helper;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    public static bool PrepareFocus(FocusFilter filter, out FocusFilterResult targetsResult)
    {
        var allCodes = Collector.LoadAllCodes();
        return Calculator.PrepareFocus(allCodes, filter, out targetsResult);
    }

    public static Diagram LoadCurrentTreemap(FocusFilter filter)
    {
        var data = Signalert.Calculator.LoadFocus(filter);
        var dicCurrent = data.Select(o => o.Value)
            .MergeCurrent();

        return Reportor.CreateTreemapDiagram(dicCurrent, $"{filter.Subject}.Current");
    }

    public static Diagram LoadPreviousTreemap(FocusFilter filter)
    {
        var data = Signalert.Calculator.LoadFocus(filter);
        var dicCurrent = data.Select(o => o.Value)
            .MergePrevious();

        return Reportor.CreateTreemapDiagram(dicCurrent, $"{filter.Subject}.Previous");
    }

    #region diagram data

    public static bool PrepareDots(FocusFilter filter)
    {
        var allCodes = Collector.LoadAllCodes();
        if (Calculator.PrepareDots(filter, allCodes, out var dic))
        {
            foreach (var kv in dic)
            {
                var sets = Calculator.LoadSets(kv.Key);
                kv.Value.ForEach(x =>
                {
                    x.Code = kv.Key;
                    x.SetKeys = sets.GetSets(x.TradeDate);
                });
            }

            var allDots = dic.Select(o => o.Value).UnionAll();

            typeof(DotOfBuyingOrSelling)
                .LocalFile($"{filter.Identity}.Sankey")
                .WriteFile(allDots.Select(o => new DotRecord(o)).ObjToJson());

            var dotsOfBuyings = allDots.Where(o => o.IsDotOfBuying)
                .Select(o => o.SetKeys)
                .MergeToDictionary();

            var dotsOfSelling = allDots.Where(o => !o.IsDotOfBuying)
                .Select(o => o.SetKeys)
                .MergeToDictionary();

            typeof(DotOfBuyingOrSelling)
                .LocalFile($"{filter.Identity}.Buying")
                .WriteFile(dotsOfBuyings.ObjToJson());

            typeof(DotOfBuyingOrSelling)
                .LocalFile($"{filter.Identity}.Selling")
                .WriteFile(dotsOfSelling.ObjToJson());
        }

        return true;
    }

    public static List<KeyValuePair<string, List<DotInfo>>> LoadDots(
        FocusFilter filter,
        RenderView? request,
        out Dictionary<string, int> dotsOfBuyings,
        out Dictionary<string, int> dotsOfSelling
    )
    {
        dotsOfBuyings = typeof(DotOfBuyingOrSelling)
            .LocalFile($"{filter.Identity}.Buying")
            .ReadFileAs<Dictionary<string, int>>();


        dotsOfSelling = typeof(DotOfBuyingOrSelling)
            .LocalFile($"{filter.Identity}.Selling")
            .ReadFileAs<Dictionary<string, int>>();

        return Reportor.LoadDots(filter)
            .ExtendedDots(request);
    }

    public static List<KeyValuePair<string, List<DotInfo>>> LoadDots(
        FocusFilter filter,
        RenderView? request
    )
    {
        return Reportor.LoadDots(filter)
            .ExtendedDots(request);
    }

    #endregion

    public static List<StockSets> FilterStockSets(List<StockSets> sets)
    {
        return sets.Where(o =>Infrastructures.Indicators.Helper.JudgeForBuying(o)).ToList();
    }

}