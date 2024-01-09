//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.ServiceCentre;

/// <summary>
/// 
/// </summary>
public interface IConfig
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    T Read<T>( string filePath, Func<T> defaultValue = null );
}