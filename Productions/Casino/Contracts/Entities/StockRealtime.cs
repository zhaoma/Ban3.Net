using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Sites.ViaNetease.Entries;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class StockRealtime
{
    public static Dictionary<string, StockRuntimeRecord> Records =>
        Config.CacheKey<StockRealtime>("all")
            .LoadOrSetDefault<Dictionary<string, StockRuntimeRecord>>(
                typeof(StockRealtime).LocalFile()
            );

    public static float Close(string code)
    {
        if (Records.TryGetValue(code, out var r))
        {
            return r.Close;
        }

        return 0;
    }

    protected static object Lock=new ();
    protected static Dictionary<string, StockRuntimeRecord> _records;
    
    public static void Append(StockRecord sr)
    {
        var r=new StockRuntimeRecord(sr);
        lock (Lock)
        {
            _records ??= new Dictionary<string, StockRuntimeRecord>();

            if (_records.ContainsKey(r.Code))
            {
                _records[r.Code] = r;
            }
            else
            {
                _records.Add(r.Code,r);
            }
        }
    }

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