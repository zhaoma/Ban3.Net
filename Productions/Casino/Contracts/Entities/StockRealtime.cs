using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Sites.ViaNetease.Entries;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 实时行情
/// </summary>
public class StockRealtime
{
    /// 
    public StockRealtime()
    {
        _records= Config.CacheKey<StockRealtime>("all")
            .LoadOrSetDefault<Dictionary<string, StockRuntimeRecord>>(
                typeof(StockRealtime).LocalFile()
            );
    }

    /// <summary>
    /// 实时行情
    /// </summary>
    public static Dictionary<string, StockRuntimeRecord> Records =>_records;

    /// <summary>
    /// 最新收盘价
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static float Close(string code)
    {
        if (Records.TryGetValue(code, out var r))
        {
            return r.Close;
        }

        return 0;
    }

    private static Dictionary<string, StockRuntimeRecord> _records;
    
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sr"></param>
    public static void Append(StockRecord sr)
    {
        var r=new StockRuntimeRecord(sr);
        _records.AddOrReplace(r.Code, r);
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="dic"></param>
    public static void Append(Dictionary<string, StockRecord> dic)
    {
        dic.AsParallel()
            .ForAll(o =>
            {
                Append(o.Value);
            });

        typeof(StockRealtime)
            .LocalFile()
            .WriteFile(_records.ObjToJson());
    }
}