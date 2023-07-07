using System.Runtime.Caching;
using System;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.RuntimeCaching;

/// <summary>
/// 运行时缓存处理
/// </summary>
public static class Helper
{
    /// see LoadOrSetDefault below
    public static T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, DateTime absoluteTime)
        => key.LoadOrSetDefault(defaultValue, absoluteTime, null, null);

    /// see LoadOrSetDefault below
    public static T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, int minutes)
        => key.LoadOrSetDefault(defaultValue, null, minutes, null);

    /// see LoadOrSetDefault below
    public static T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, string localFile)
        => key.LoadOrSetDefault(defaultValue, null, null, localFile);

    /// see LoadOrSetDefault below
    public static T LoadOrSetDefault<T>(this string key, string localFile) 
        => key.LoadOrSetDefault(() => localFile.ReadFileAs<T>() , localFile);

    /// <summary>
    /// 从缓存加载或是设置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <param name="absoluteTime"></param>
    /// <param name="minutes"></param>
    /// <param name="localFile"></param>
    /// <returns></returns>
    public static T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, DateTime? absoluteTime, int? minutes,
        string localFile)
    {
        var cached = key.LoadFromMemoryCache().JsonToObj<T>();

        if (cached != null) return cached;

        cached =  defaultValue();

        if (absoluteTime != null)
            AppendToMemoryCache(key, cached.ObjToJson(), absoluteTime.Value);

        if (minutes != null)
            AppendToMemoryCache(key, cached.ObjToJson(), minutes.Value);

        if (!string.IsNullOrEmpty(localFile))
            AppendToMemoryCache(key, cached.ObjToJson(), localFile);

        return cached;
    }

    /// <summary>
    /// 读取
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string LoadFromMemoryCache(this string key)
    {
        return MemoryCache.Default.Get(key) + "";
    }

    /// <summary>
    /// 写入不过期缓存
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="val">键值</param>
    public static void AppendToMemoryCache(this string key, string val)
    {
        MemoryCache.Default.Set(
            new CacheItem(key, val),
            new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable });
    }

    /// <summary>
    /// 写入一天过期缓存
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="val">键值</param>
    public static void AppendToMemoryCacheOneDay(this string key, string val)
    {
        key.AppendToMemoryCache(val, DateTime.Now.AddDays(1));
    }

    /// <summary>
    /// 写入绝对过期缓存
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="val">键值</param>
    /// <param name="absoluteTime">绝对过期时间</param>
    public static void AppendToMemoryCache(this string key, string val, DateTime absoluteTime)
        => MemoryCache.Default.Set(key, val, absoluteTime);

    /// <summary>
    /// 写入相对过期缓存
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="val">键值</param>
    /// <param name="minutes">存活分钟数</param>
    public static void AppendToMemoryCache(this string key, string val, int minutes)
        => MemoryCache.Default.Set(key, val, DateTime.Now.AddMinutes(minutes));

    /// <summary>
    /// 写入文件以来缓存
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="val">键值</param>
    /// <param name="dependencyFile">依赖文件</param>
    public static void AppendToMemoryCache(this string key, string val, string dependencyFile)
        => MemoryCache.Default.Set(key, val, new CacheItemPolicy
        {
            Priority = CacheItemPriority.Default,
            ChangeMonitors = { new HostFileChangeMonitor(new[] { dependencyFile }) }
        });

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="key">键名</param>
    public static void RemoveFromMemoryCache(this string key)
        => MemoryCache.Default.Remove(key);
}