/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（内存缓存）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.IO;
using System.Runtime.Caching;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 内存缓存
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="localConfigFile"></param>
        /// <returns></returns>
        public static T LoadOrSetDefault<T>(this string key, T defaultValue, string localConfigFile="")
        {
            var cached = key.LoadFromMemoryCache().JsonToObj<T>();

            if (cached == null
		            && defaultValue != null)
            {
                if (!string.IsNullOrEmpty(localConfigFile))
                {
                    localConfigFile.WriteFile(defaultValue.ObjToJson());
                    key.AppendToMemoryCache(defaultValue.ObjToJson(), localConfigFile);
                }
                return defaultValue;
            }

            return cached!;
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string LoadFromMemoryCache( this string key )
        {
            return MemoryCache.Default.Get( key ) + "";
        }

        /// <summary>
        /// 写入不过期缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="val">键值</param>
        public static void AppendToMemory(
        this string key,
        string val
        )
        {
            MemoryCache.Default.Set(
		        new CacheItem(key,val),
		        new CacheItemPolicy { Priority=CacheItemPriority.NotRemovable});
        }

        /// <summary>
        /// 写入一天过期缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="val">键值</param>
        public static void AppendToMemoryCacheOneDay(
                this string key,
                string val
        )
        {
            key.AppendToMemoryCache( val, DateTime.Now.AddDays( 1 ) );
        }

        /// <summary>
        /// 写入绝对过期缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="val">键值</param>
        /// <param name="absoluteTime">绝对过期时间</param>
        public static void AppendToMemoryCache(
                this string key,
                string val,
                DateTime absoluteTime
        )
        {
            MemoryCache.Default.Set( key, val, absoluteTime );
        }

        /// <summary>
        /// 写入相对过期缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="val">键值</param>
        /// <param name="minutes">存活分钟数</param>
        public static void AppendToMemoryCache(
                this string key,
                string val,
                int minutes
        )
        {
            MemoryCache.Default.Set( key, val, DateTime.Now.AddMinutes( minutes ) );
        }

        /// <summary>
        /// 写入文件以来缓存
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="val">键值</param>
        /// <param name="dependencyFile">依赖文件</param>
        public static void AppendToMemoryCache(
                this string key,
                string val,
                string dependencyFile
        )
        {
            var policy = new CacheItemPolicy { Priority = CacheItemPriority.Default };
            policy.ChangeMonitors.Add( new HostFileChangeMonitor( new[] { dependencyFile } ) );
            MemoryCache.Default.Set( key, val, policy );
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键名</param>
        public static void RemoveFromMemoryCache(
                this string key )
        {
            MemoryCache.Default.Remove( key );
        }
    }
}