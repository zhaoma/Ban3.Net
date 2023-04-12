/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            请求接口申明
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Common.Servers;

namespace Ban3.Infrastructures.Common.Interfaces
{
    /// <summary>
    /// 请求接口申明
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// 要请求的资源
        /// </summary>
        /// <returns></returns>
        NetResource NetResource();

        /// <summary>
        /// 服务端为jsonp?
        /// </summary>
        bool ResourceIsJsonp { get; set; }

        /// <summary>
        /// jsonp的前缀
        /// </summary>
        string JsonpPrefix { get; set; }
    }
}

