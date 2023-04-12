/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            支持的缓存容器
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Enums
{
    /// <summary>
    /// 支持的缓存容器
    /// </summary>
    public enum SupportedCacheContainer
    {
        /// <summary>
        /// runtime.cache
        /// </summary>
        Memory,
        /// <summary>
        /// Redis
        /// </summary>
        Redis
    }
}

