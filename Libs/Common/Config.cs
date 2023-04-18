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
        public static readonly IConfiguration AppConfiguration;

        /// <summary>
        /// 静态构造
        /// </summary>
        static Config()
        {
            AppConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", false, true)
                .Build();
        }
        
        /// <summary>
        /// 默认配置(文件保存用)
        /// </summary>
        public static string FilesStorageRootPath => AppConfiguration["FilesStorage:RootPath"]+"";

        /// <summary>
        /// web访问根目录
        /// </summary>
        public static string FilesStorageRootUrl => AppConfiguration["FilesStorage:RootUrl"]+""; 
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public delegate void DataHandle<in T>(T data);
}