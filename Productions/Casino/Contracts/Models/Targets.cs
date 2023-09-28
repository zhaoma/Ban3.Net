#nullable enable
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Sites.ViaTushare.Entries;
using Ban3.Productions.Casino.Contracts.Extensions;

namespace Ban3.Productions.Casino.Contracts.Models;

/// <summary>
/// 标的
/// </summary>
public class Targets
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, Target> Data { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Targets()
    {
        Data = typeof(Targets).LocalFile()
                   .ReadFileAs<Dictionary<string, Target>>()
               ?? new Dictionary<string, Target>();
    }

    /// <summary>
    /// 复位昨天的记录
    /// </summary>
    public void Reset()
    {
        if (Data.Any())
        {
            foreach (var d in Data)
            {
                d.Value.Ignore = true;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="points"></param>
    /// <param name="price"></param>
    /// <param name="sets"></param>
    /// <param name="days"></param>
    public void AppendTarget(
        Stock stock,
        List<TimelinePoint> points,
        StockPrice price,
        StockSets sets,
        int days
    )
    {
        var t = new Target(stock, points, price, sets,days);
        if (Data.TryGetValue(stock.Code, out var _))
        {
            Data[stock.Code] = t;
        }
        else
        {
            if (!t.Ignore)
                Data.AddOrReplace(stock.Code, t);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Save()
    {
        typeof(Targets).LocalFile()
            .WriteFile(Data.ObjToJson());
    }

    /// 
    public void Ignore(string code)
    {
        if (Data.ContainsKey(code))
        {
            Data[code].Ignore = true;
            Data[code].LastAccess = DateTime.Now;
            Save();
        }
    }

    /// 
    public void Skip(string code)
    {
        if (Data.ContainsKey(code))
        {
            Data[code].LastAccess = DateTime.Now;
            Save();
        }
    }

    /// 
    public Target? PopOne(StockGroup? selectedGroup)
    {
        if (Data.Any(o => !o.Value.Ignore))
        {
            return Data
        .Where(o => selectedGroup == null || o.Key.StockGroup().Equals(selectedGroup.Value))
        .OrderBy(o => o.Value.LastAccess).FirstOrDefault().Value;
        }

        return null;
    }

    /// 
    public Target? Get(string code)
    {
        if (Data.TryGetValue(code, out var target))
            return target;

        return null;
    }

    /// <summary>
    /// 分组统计
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="getKey"></param>
    /// <returns></returns>
    public Dictionary<TKey, int> Counter<TKey>(Func<Target,TKey> getKey) =>
        Data
        .Where(o => !o.Value.Ignore)
        .GroupBy(o => getKey(o.Value))
        .Select(o => new
        {
            group = o.Key,
            counter = o.Count()
        })
    .ToDictionary(o => o.group, o => o.counter);

    /// <summary>
    /// 价格区间计数
    /// </summary>
    /// <returns></returns>
    public Dictionary<PriceScope, int> PriceScopes()
        => Counter(target => ((double)target.LatestPrice.Close).PriceScope());

    /// <summary>
    /// 所属板块计数
    /// </summary>
    /// <returns></returns>
    public Dictionary<StockGroup, int> StockGroups()
        => Counter(target => target.Stock.Symbol.StockGroup());
    /*
    public Dictionary<CapitalScope,int> CapitalScopes()
    => Counter(target => (target.Stock.).PriceScope());
    */

    /// <summary>
    /// 每个group
    /// </summary>
    /// <returns></returns>
    public Dictionary<StockGroup, Target> FocusOnEveryGroup()
    {
        var result = new Dictionary<StockGroup, Target>();

        var counter = StockGroups();

        foreach (var kvp in counter)
        {
            var t = PopOne(kvp.Key);
            if (t != null)
            {
                result.Add(kvp.Key, t);
            }
        }

        return result;
    }
}