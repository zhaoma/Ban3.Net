using System;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Request.Hybird;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class SetCache<T>
{
    /// <summary>
    /// 
    /// </summary>
    public SetCache()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <param name="key"></param>
    /// <param name="profile"></param>
    public SetCache(T item, Func<T, string> key, CacheProfile profile)
    {
        CacheItem = new CacheItem<T>(key(item), item, profile);
    }

    /// <summary>
    /// 
    /// </summary>
    public CacheItem<T> CacheItem { get; set; }
}

