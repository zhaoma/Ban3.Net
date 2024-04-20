﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Threading.Tasks;

namespace Ban3.Infrastructures.Components.Services;

/// <summary>
/// 数据缓存服务
/// </summary>
public interface ICacheServer
{
    /// <summary>
    /// 设置缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool Set<T>(string key, T value);

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    T Load<T>(string key);

    /// <summary>
    /// 移除缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Remove(string key);

    /// <summary>
    /// 清空缓存
    /// </summary>
    /// <returns></returns>
    bool Flush();

    Task<bool> SetAsync<T>(string key, T value);

    Task<T> LoadAsync<T>(string key);

    Task<bool> RemoveAsync(string key);

    Task<bool> FlushAsync();

}
