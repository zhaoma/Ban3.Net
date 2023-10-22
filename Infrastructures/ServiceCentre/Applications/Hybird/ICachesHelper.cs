using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Models.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 缓存处理声明
/// </summary>
public interface ICachesHelper
{
    /// <summary>
    /// 设置缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="cachesProfile"></param>
    /// <returns></returns>
    Task<bool> TrySet<T>(string key, T data, CachesProfile cachesProfile);

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="savedData"></param>
    /// <returns></returns>
    Task<bool> TryGet<T>(string key, out T savedData);

    /// <summary>
    /// 移除一项缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<bool> TryRemove(string key);

    /// <summary>
    /// 清空缓存
    /// </summary>
    /// <returns></returns>
    Task<bool> TryFlush();
}
