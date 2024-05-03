﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Autofac;

namespace Ban3.Implements.Alpha;

/// <summary>
/// 
/// </summary>
public static class Settings
{
    public static IContainer? Instance;

    public static void Init()
    {
        var builder = new ContainerBuilder();

        builder.RegisterImplements();

        Instance = builder.Build();
    }

    public static void RegisterImplements(this ContainerBuilder builder)
    {
        builder.RegisterType<Applications.CasinoServer>()
            .As<Infrastructures.Contracts.Applications.ICasinoServer>()
            .SingleInstance();

        builder.RegisterType<Components.CacheServer.RuntimeCaching>()
            .As<Infrastructures.Components.ICacheServer>()
            .SingleInstance();

        builder.RegisterType<Components.ChartServer.UtilizeEcharts>()
            .As<Infrastructures.Components.IChartServer>()
            .SingleInstance();

        builder.RegisterType<Components.DatabaseServer.UtilizeJson>()
            .As<Infrastructures.Components.IDatabaseServer>()
            .SingleInstance();

        builder.RegisterType<Components.HttpServer.UtilizeNetHttp>()
            .As<Infrastructures.Components.IHttpServer>()
            .SingleInstance();

        builder.RegisterType<Components.LogServer.UtilizeLog4net>()
            .As<Infrastructures.Components.ILoggerServer>()
            .SingleInstance();

        builder.RegisterType<Components.MailServer.UtilizeOutlook>()
            .As<Infrastructures.Components.IMailServer>()
            .SingleInstance();

        builder.RegisterType<Components.MessageServer.UtilizeSignalR>()
            .As<Infrastructures.Components.IMessageServer>()
            .SingleInstance();
    }

    public static T Resolve<T>() => Instance.Resolve<T>();
}
