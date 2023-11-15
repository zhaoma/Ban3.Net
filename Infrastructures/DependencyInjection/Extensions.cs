// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;

using Ban3.Infrastructures.ServiceCentre.ServiceTags;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;

using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

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
        public static IHostBuilder UseAutofac( this IHostBuilder host )
        {
            return host.UseServiceProviderFactory( new AutofacServiceProviderFactory() );
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
        public static void RegisterOnDependencies( this ContainerBuilder container )
        {
            var libs = DependencyContext.Default?.CompileLibraries
                                        .Where( lib => lib.Serviceable == false && lib.Type == "project" )
                                        .Select( lib => lib.Name )
                                        .ToList();

            if( libs == null ) return;

            var assemblies = libs.Select( lib => AssemblyLoadContext.Default.LoadFromAssemblyName( new AssemblyName( lib ) ) )
                                 .ToArray();

            container
               .RegisterAssemblyTypes( assemblies )
               .Where( type => type.IsAbstract == false && type.IsAssignableTo<ISingletonTag>() )
               .AsSelf()
               .AsImplementedInterfaces()
               .SingleInstance()
               .PropertiesAutowired();

            container
               .RegisterAssemblyTypes( assemblies )
               .Where( type => type.IsAbstract == false && type.IsAssignableTo<IScopedTag>() )
               .AsSelf()
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope()
               .PropertiesAutowired();

            container
               .RegisterAssemblyTypes( assemblies )
               .Where( type => type.IsAbstract == false && type.IsAssignableTo<ITransientTag>() )
               .AsSelf()
               .AsImplementedInterfaces()
               .InstancePerDependency()
               .PropertiesAutowired();

            container
               .RegisterAssemblyTypes( assemblies )
               .Where( type => type.IsAbstract == false )
               .AsSelf()
               .InstancePerDependency()
               .PropertiesAutowired()
               .PreserveExistingDefaults();
        }

        #endregion

        const string AutofacConfigFile = "Config/autofac.json";
    }
}