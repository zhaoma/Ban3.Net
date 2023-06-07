/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            设置项定义（配置获取）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Diagnostics;
using System.IO;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Rougamo;

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

            log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(Environment.CurrentDirectory,
                "log4net.config")));

            LocalStorage = new Models.LocalStorage
            {
                RootPath = AppConfiguration["FilesStorage:RootPath"] + "",
                RootUrl = AppConfiguration["FilesStorage:RootUrl"] + ""
            };

            TraceSetting = new TraceSetting
            {
                BindFlags = AppConfiguration["TraceSetting:BindFlags"] + "" == "all"
                    ? AccessFlags.All
                    : AccessFlags.Public,
                Timing = AppConfiguration["TraceSetting:Timing"] + "" != "false",
                LoggingArguments = AppConfiguration["TraceSetting:LoggingArguments"] + "" == "true"
            };
        }

        public static Models.LocalStorage LocalStorage { get; set; }

        public static Models.TraceSetting TraceSetting { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public delegate void DataHandle<in T>(T data);
}