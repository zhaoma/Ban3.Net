#nullable enable
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Sites.ViaTushare.Entries;

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
        Data = typeof(Models.Targets).LocalFile()
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
        Data.AddOrReplace(stock.Code, new Target(stock, points, price,sets));
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
            return Data.OrderBy(o=>o.Value.LastAccess).FirstOrDefault().Value;
        }

        return null;
    }
}