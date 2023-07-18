using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 收藏夹
/// </summary>
public class Favorite
{
    /// <summary>
    /// 标识
    /// </summary>
    private readonly string _identity="all";

    ///
    public Favorite(){}

    ///
    public Favorite(string identity)
    {
        _identity = identity;
    }

    /// <summary>
    /// 运行时缓存收藏夹
    /// </summary>
    public Dictionary<string, FavoriteRecord> Records =>
        Config.CacheKey<FavoriteRecord>(_identity)
            .LoadOrSetDefault<Dictionary<string, FavoriteRecord>>(
                typeof(Favorite).LocalFile()
            );

    static readonly object Lock = new();
    Dictionary<string, FavoriteRecord> _records;

    /// <summary>
    /// 操作一个标的
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stock"></param>
    /// <param name="price"></param>
    /// <param name="withoutUpdate"></param>
    public void ParseOne(StockFavoriteType type, Stock stock, float price, bool withoutUpdate = false)
        => ParseOne(type, stock.Code, stock.Symbol, stock.Name, price, withoutUpdate);

    /// <summary>
    /// 操作一个标的
    /// </summary>
    /// <param name="type"></param>
    /// <param name="code"></param>
    /// <param name="symbol"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="withoutUpdate"></param>
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

    /// <summary>
    /// 更新收藏夹
    /// </summary>
    public void Update()
    {
        typeof(Favorite)
            .LocalFile(_identity)
            .WriteFile(_records.ObjToJson());
    }
}