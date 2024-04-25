//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components;
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

    public RuntimeCaching(ILoggerServer logger)
    {
        _logger = logger;
    }

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

    public T Load<T>(string key)
    {
        try
        {
            return (_cache.Get(key) + "").JsonToObj<T>();
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return default(T);
    }

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

    public bool Flush() => false;

    public Task<bool> SetAsync<T>(string key, T value)
        => Task.FromResult(Set(key, value));

    public Task<T> LoadAsync<T>(string key)
        => Task.FromResult(Load<T>(key));

    public Task<bool> RemoveAsync(string key)
        => Task.FromResult(Remove(key));

    public Task<bool> FlushAsync()
        =>Task.FromResult(false);
}
