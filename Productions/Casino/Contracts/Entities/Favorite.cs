using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class Favorite
{
    private string Identity="all";

    public Favorite(){}

    public Favorite(string identity)
    {
        Identity = identity;
    }

    public Dictionary<string, FavoriteRecord> Records =>
        Config.CacheKey<FavoriteRecord>(Identity)
            .LoadOrSetDefault<Dictionary<string, FavoriteRecord>>(
                typeof(Favorite).LocalFile()
            );

    protected static object Lock = new();
    protected Dictionary<string, FavoriteRecord> _records;

    public void ParseOne(StockFavoriteType type, Stock stock, float price, bool withoutUpdate = false)
        => ParseOne(type, stock.Code, stock.Symbol, stock.Name, price, withoutUpdate);

    public void ParseOne(StockFavoriteType type, string code, string symbol, string name, float price, bool withoutUpdate = false)
        => Append(code, new FavoriteRecord { Type = type, Close = price, Symbol = symbol, Name = name }, withoutUpdate);

    void Append(string code, FavoriteRecord fr, bool withoutUpdate = false)
    {
        lock (Lock)
        {
            var needUpdate = true;
            _records ??= new Dictionary<string, FavoriteRecord>();

            if (_records.TryGetValue(code, out var er))
            {
                if (_records[code].Type == fr.Type)
                {
                    needUpdate = false;
                }
                else
                {
                    _records[code].Logs ??= new List<FavoriteLog>();
                    _records[code].Logs.Add(new FavoriteLog { MarkTime = er.MarkTime, Type = er.Type });
                    _records[code].Type = fr.Type;
                    _records[code].MarkTime = DateTime.Now;
                    _records[code].Close = fr.Close;
                    _records[code].Name = fr.Name;
                    _records[code].Symbol = fr.Symbol;
                }
            }
            else
            {
                _records.Add(code, fr);
            }

            if (needUpdate && !withoutUpdate)
            {
                Update();
            }
        }
    }

    public void Update()
    {
        typeof(Favorite)
            .LocalFile(Identity)
            .WriteFile(_records.ObjToJson());
    }
}