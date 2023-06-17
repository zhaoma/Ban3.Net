using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Productions.Casino.Contracts.Response;

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

    public static bool PrepareDots(FocusFilter filter)
    {
        var allCodes = Collector.LoadAllCodes();
        if (Calculator.PrepareDots(filter, allCodes, out var dic))
        {
            foreach (var kv in dic)
            {
                var sets = Calculator.LoadSets(kv.Key);
                kv.Value.ForEach(x => { x.SetKeys = sets.GetSets(x.TradeDate); });
            }

            var allDots = dic.Select(o => o.Value).UnionAll();

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

        return Calculator.LoadDots(filter)
            .ExtendedDots(request);
    }

    public static List<KeyValuePair<string, List<DotInfo>>> LoadDots(
        FocusFilter filter,
        RenderView? request
    )
    {
        return Calculator.LoadDots(filter)
            .ExtendedDots(request);
    }

    public static Dictionary<string,int> LoadDotsKey(
        FocusFilter filter,
        bool forBuying)
    {
        var key = forBuying ? $"{filter.Identity}.Buying" : $"{filter.Identity}.Selling";
        return typeof(DotOfBuyingOrSelling)
            .LocalFile(key)
            .ReadFileAs<Dictionary<string, int>>();
    }

}