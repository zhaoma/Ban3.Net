/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            请求基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Common.Interfaces;
using Ban3.Infrastructures.Common.Servers;

namespace Ban3.Infrastructures.Common.Requests
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public class NormalRequest : IRequest
    {
        /// <summary>
        /// 资源
        /// </summary>
        /// <returns></returns>
        public virtual NetResource NetResource()
        {
            return new NetResource();
        }

        /// <summary>
        /// 资源是jsonp
        /// </summary>
        public virtual bool ResourceIsJsonp { get; set; } = false;

        /// <summary>
        /// jsonp前缀
        /// </summary>
        public virtual string JsonpPrefix { get; set; } = string.Empty;
    }
}