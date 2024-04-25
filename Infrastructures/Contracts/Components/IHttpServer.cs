//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components.Entries.HttpServer;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Components;

/// <summary>
/// HTTP请求服务
/// </summary>
public interface IHttpServer
{
    /// <summary>
    /// 请求(反序列化)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    Task<T> RequestGeneric<T>(IHost host, IResource resource);

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    Task<bool> RequestVoid(IHost host, IResource resource);

    /// <summary>
    /// 请求文本
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    Task<string> RequestString(IHost host, IResource resource);

    /// <summary>
    /// 请求字节组
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    Task<byte[]> RequestBytes(IHost host, IResource resource);

    /// <summary>
    /// 下载资源
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <param name="savePath"></param>
    /// <returns></returns>
    Task<bool> Download(IHost host, IResource resource, string savePath);
}
