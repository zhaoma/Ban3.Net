using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Models.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 
/// </summary>
public interface ICachesHelper
{
    Task<bool> SetCache<T>(string key, T data, CachesProfile cachesProfile);

    Task<bool> GetCache<T>(string key, out T savedData);

    Task<bool> RemoveCache(string key);

    Task<bool> FlushCaches();
}
