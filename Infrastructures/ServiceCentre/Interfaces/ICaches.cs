using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Request;
using Ban3.Infrastructures.ServiceCentre.Response;

namespace Ban3.Infrastructures.ServiceCentre.Interfaces;

public interface ICaches
{
    Task<bool> Execute<T>(SetCache<T> request, out SetCacheResult<T> response);

     
}

