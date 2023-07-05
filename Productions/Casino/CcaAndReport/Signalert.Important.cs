using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
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
    public static bool PrepareFocus(List<Stock> allCodes,FocusFilter filter, out FocusFilterResult targetsResult)
    {
        allCodes ??= Collector.LoadAllCodes();
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

    public static bool PrepareDots(List<Stock> allCodes, FocusFilter filter)
    {
        allCodes ??= Collector.LoadAllCodes();
        if (Calculator.PrepareDots(filter, allCodes, out var dic))
        {
            foreach (var kv in dic)
            {
                var sets = Calculator.LoadSets(kv.Key);
                kv.Value.ForEach(x =>
                {
                    x.Code = kv.Key;
                    x.SetKeys = sets.GetSetKeys(x.TradeDate);
                });
            }

            var allDots = dic.Select(o => o.Value).UnionAll();

            typeof(DotOfBuyingOrSelling)
                .LocalFile($"{filter.Identity}.Sankey")
                .WriteFile(allDots.Select(o => new DotRecord(o)).ObjToJson());

            var dotsOfBuying = allDots.Where(o => o.IsDotOfBuying)
                .Select(o => o.SetKeys)
                .MergeToDictionary();

            var dotsOfSelling = allDots.Where(o => !o.IsDotOfBuying)
                .Select(o => o.SetKeys)
                .MergeToDictionary();

            typeof(DotOfBuyingOrSelling)
                .LocalFile($"{filter.Identity}.Buying")
                .WriteFile(dotsOfBuying.ObjToJson());

            typeof(DotOfBuyingOrSelling)
                .LocalFile($"{filter.Identity}.Selling")
                .WriteFile(dotsOfSelling.ObjToJson());
        }

        return true;
    }

    #endregion
    
}