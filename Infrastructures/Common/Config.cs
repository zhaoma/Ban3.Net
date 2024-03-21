//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;

using Microsoft.Extensions.Configuration;

using System;
using System.IO;

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
        if( SettingsStandby )
        {
            AppConfiguration = new ConfigurationBuilder()
                              .AddJsonFile( "appSettings.json", false, true )
                              .Build();

            LocalStorage = new LocalStorage
            {
                RootPath = GetValue( "FilesStorage:RootPath" ),
                RootUrl = GetValue( "FilesStorage:RootUrl" )
            };
        }

        if( LoggerStandby )
        {
            log4net.Config.XmlConfigurator
                   .Configure( new FileInfo( Path.Combine( Environment.CurrentDirectory, "log4net.config" ) ) );
        }
    }

    /// <summary>
    /// 检查 appSettings.json 存在
    /// </summary>
    public static bool SettingsStandby => File.Exists( "appSettings.json".WorkPath() );

    /// <summary>
    /// 检查 log4net.config 存在
    /// </summary>
    public static bool LoggerStandby => File.Exists( "log4net.config".WorkPath() );

    /// <summary>
    /// 本地文件存储配置
    /// </summary>
    public static LocalStorage? LocalStorage { get; set; }

    /// <summary>
    /// 获取配置值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetValue( string key )
        => AppConfiguration?[ key ] + "";
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="data"></param>
public delegate void DataHandle<in T>( T data );