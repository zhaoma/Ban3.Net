//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Autofac;

namespace Ban3.Implements.Alpha;

/// <summary>
/// 
/// </summary>
public static class Settings
{
    /// <summary>
    /// 
    /// </summary>
    public static IContainer? Instance;

    /// <summary>
    /// 
    /// </summary>
    public static void Init()
    {
        var builder = new ContainerBuilder();

        builder.RegisterImplements();

        Instance = builder.Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterImplements(this ContainerBuilder builder)
    {
        builder.RegisterType<Applications.CasinoServer>()
            .As<Infrastructures.Contracts.Applications.ICasinoServer>()
            .SingleInstance();

        builder.RegisterType<Components.CacheServer.RuntimeCaching>()
            .As<Infrastructures.Contracts.Components.ICacheServer>()
            .SingleInstance();

        builder.RegisterType<Components.ChartServer.UtilizeEcharts>()
            .As<Infrastructures.Contracts.Components.IChartServer>()
            .SingleInstance();

        builder.RegisterType<Components.DatabaseServer.UtilizeJson>()
            .As<Infrastructures.Contracts.Components.IDatabaseServer>()
            .SingleInstance();

        builder.RegisterType<Components.HttpServer.UtilizeNetHttp>()
            .As<Infrastructures.Contracts.Components.IHttpServer>()
            .SingleInstance();

        builder.RegisterType<Components.LogServer.UtilizeLog4net>()
            .As<Infrastructures.Contracts.Components.ILoggerServer>()
            .SingleInstance();

        builder.RegisterType<Components.MailServer.UtilizeOutlook>()
            .As<Infrastructures.Contracts.Components.IMailServer>()
            .SingleInstance();

        builder.RegisterType<Components.MessageServer.UtilizeSignalR>()
            .As<Infrastructures.Contracts.Components.IMessageServer>()
            .SingleInstance();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Resolve<T>() => Instance.Resolve<T>();
}
