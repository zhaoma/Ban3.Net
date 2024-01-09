//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 存储接口声明
/// </summary>
public interface IStoragesHelper
{
    /// <summary>
    /// 保存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="getKey"></param>
    /// <returns></returns>
    Task<bool> TrySave<T>( T data, Func<T, string> getKey );

    /// <summary>
    /// 保存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<bool> TrySave<T>( T data, string key );

    /// <summary>
    /// 读取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<T> TryLoad<T>( string key );

    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="getKey"></param>
    /// <returns></returns>
    Task<bool> TryDelete<T>( T data, Func<T, string> getKey );

    /// <summary>
    /// 删除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<bool> TryDelete<T>( string key );

    /// <summary>
    /// 查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryQuery<T>( Predicate<T> predicate, Action<IEnumerable<T>>? action );
}