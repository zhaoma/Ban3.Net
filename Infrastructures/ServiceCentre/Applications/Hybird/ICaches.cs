﻿using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Request.Hybird;
using Ban3.Infrastructures.ServiceCentre.Response.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 
/// </summary>
public interface ICaches
{
    /// <summary>
    /// SetCache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">SetCache</param>
    /// <param name="response">SetCacheResult</param>
    /// <returns></returns>
    Task<bool> Execute<T>(SetCache<T> request, out SetCacheResult<T> response);

    /// <summary>
    /// GetCache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">GetCache</param>
    /// <param name="response">GetCacheResult</param>
    /// <returns></returns>
    Task<bool> Execute<T>(GetCache<T> request, out GetCacheResult<T> response);
}
