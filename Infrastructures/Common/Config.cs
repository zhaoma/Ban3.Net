﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            设置项定义（配置获取）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.IO;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;
using Microsoft.Extensions.Configuration;
using Rougamo;

namespace Ban3.Infrastructures.Common;

/// <summary>
/// 配置获取
/// </summary>
public class Config
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly IConfiguration? AppConfiguration;

    /// <summary>
    /// 静态构造
    /// </summary>
    static Config()
    {
        if (SettingsStandby)
        {
            AppConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", false, true)
                .Build();

            LocalStorage = new LocalStorage
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

        if (LoggerStandby)
        {
            log4net.Config.XmlConfigurator
                .Configure(new FileInfo(Path.Combine(Environment.CurrentDirectory, "log4net.config")));
        }
    }

    public static bool SettingsStandby => File.Exists("appSettings.json".WorkPath());

    public static bool LoggerStandby => File.Exists("log4net.config".WorkPath());

    /// <summary>
    /// 本地文件存储配置
    /// </summary>
    public static LocalStorage? LocalStorage { get; set; }

    /// <summary>
    /// 跟踪配置
    /// </summary>
    public static TraceSetting? TraceSetting { get; set; }

    /// <summary>
    /// 获取配置值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string? GetValue(string key)
        => AppConfiguration?[key];
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="data"></param>
public delegate void DataHandle<in T>(T data);