#nullable enable
using System;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
    /// 
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="points"></param>
    /// <param name="price"></param>
    /// <param name="sets"></param>
    public void AppendTarget(
        Stock stock,
        List<TimelinePoint> points,
        StockPrice price,
        StockSets sets
    )
    {
        var t = new Target(stock, points, price, sets);
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
    public Target? PopOne()
    {
        if (Data.Any(o => !o.Value.Ignore))
        {
            return Data.OrderBy(o => o.Value.LastAccess).FirstOrDefault().Value;
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
}