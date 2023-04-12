/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            设置项定义（配置获取）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.IO;

using Ban3.Infrastructures.Common.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Ban3.Infrastructures.Common
{
    /// <summary>
    /// 配置获取
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly IConfiguration Configuration;

        /// <summary>
        /// 静态构造
        /// </summary>
        static Config()
        {
            Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json", false, true)
                    .Build();
        }

        /// <summary>
        /// 获取配置节
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IConfiguration GetSection( string key )
        {
            return Configuration.GetSection( key );
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public delegate void DataHandle<in T>(T data);
}