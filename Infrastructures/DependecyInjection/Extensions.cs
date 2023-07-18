﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            使用Autofac完成注入
 * reference:https://autofac.org/
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

using Autofac;
using Autofac.Configuration;
using Autofac.log4net;
using Autofac.Extensions.DependencyInjection;

using Ban3.Infrastructures.Interfaces.ServiceTags;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;

namespace Ban3.Infrastructures.DependecyInjection
{
    /// <summary>
    /// 使用Autofac完成注入
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 使用配置文件注册
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHostBuilder UseAutofac(this IHostBuilder host)
        {
            return host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }

        #region DI

        /// <summary>
        /// ContainerBuilder load config/autofac.json
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterOnConfig( this ContainerBuilder container )
        {
            var config = new ConfigurationBuilder();
            var configSource = new JsonConfigurationSource
            {
                    Path = AutofacConfigFile,
                    Optional = false,
                    ReloadOnChange = true
            };
            config.Add( configSource );

            var configModule = new ConfigurationModule( config.Build() );
            container.RegisterModule( configModule );
        }

        /// <summary>
        /// 通过依赖注入
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterOnDependencies(this ContainerBuilder container)
        {
            var libs = DependencyContext.Default?.CompileLibraries
                                        .Where(lib => lib.Serviceable == false && lib.Type == "project")
                                        .Select(lib => lib.Name)
                                        .ToList();

            if (libs == null) return;

            var assemblies = libs.Select(lib => AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib)))
                                 .ToArray();

            container
                    .RegisterAssemblyTypes(assemblies)
                    .Where(type => type.IsAbstract == false && type.IsAssignableTo<ISingletonTag>())
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .SingleInstance()
                    .PropertiesAutowired();

            container
                    .RegisterAssemblyTypes(assemblies)
                    .Where(type => type.IsAbstract == false && type.IsAssignableTo<IScopedTag>())
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();

            container
                    .RegisterAssemblyTypes(assemblies)
                    .Where(type => type.IsAbstract == false && type.IsAssignableTo<ITransientTag>())
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .PropertiesAutowired();

            container
                    .RegisterAssemblyTypes(assemblies)
                    .Where(type => type.IsAbstract == false)
                    .AsSelf()
                    .InstancePerDependency()
                    .PropertiesAutowired()
                    .PreserveExistingDefaults();
        }

        #endregion

        #region Log4net

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void UseLog4net(this ContainerBuilder container)
        {
            var log4netModule = new Log4NetModule(Log4netConfigFile, true);

            container.RegisterModule(log4netModule);
        }

        #endregion

        const string AutofacConfigFile = "Config/autofac.json";
        const string Log4netConfigFile = "Config/log4net.config";
    }
}