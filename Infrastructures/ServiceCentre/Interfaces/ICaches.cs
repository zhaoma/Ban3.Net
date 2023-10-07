using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Request;
using Ban3.Infrastructures.ServiceCentre.Response;

namespace Ban3.Infrastructures.ServiceCentre.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ICaches
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request"></param>
    /// <param name="response"></param>
    /// <returns></returns>
    Task<bool> Execute<T>(SetCache<T> request, out SetCacheResult<T> response);

     
}

