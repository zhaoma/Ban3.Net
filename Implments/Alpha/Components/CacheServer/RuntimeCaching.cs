//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Components;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Components.CacheServer;

/// <summary>
/// 使用Runtime.Caching实现缓存组件
/// </summary>
public class RuntimeCaching : ICacheServer
{
    private readonly ILoggerServer _logger;
    private MemoryCache _cache = MemoryCache.Default;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public RuntimeCaching(ILoggerServer logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Set<T>(string key, T value)
    {
        try
        {
            _cache.Set(
                key,
                value.ObjToJson(),
                new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable });

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T Load<T>(string key)
    {
        try
        {
            return (_cache.Get(key) + "").JsonToObj<T>()!;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Remove(string key)
    {
        try
        {
            _cache.Remove(key);

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Flush() => false;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public Task<bool> SetAsync<T>(string key, T value)
        => Task.FromResult(Set(key, value));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public Task<T> LoadAsync<T>(string key)
        => Task.FromResult(Load<T>(key));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Task<bool> RemoveAsync(string key)
        => Task.FromResult(Remove(key));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<bool> FlushAsync()
        =>Task.FromResult(false);
}
