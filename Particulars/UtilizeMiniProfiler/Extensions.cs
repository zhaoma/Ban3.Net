/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * 性能分析组件miniProfiler扩展
 * https://miniprofiler.com/dotnet/AspDotNetCore
 * 1.Edit your Startup.cs to add the middleware and configure options
 * 2.Configure MiniProfiler with the options you want
 * 3.Add Tag Helpers in _ViewImports.cshtml:
 * @using StackExchange.Profiling
 * @addTagHelper *, MiniProfiler.AspNetCore.Mvc
 * 4.Add MiniProfiler to your view layout (Shared/_Layout.cshtml by default):
 * <mini-profiler />
 * —————————————————————————————————————————————————————————————————————————————
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ban3.Infrastructures.Plugins.UtilizeMiniProfiler
{
    /// <summary>
    /// 性能分析组件miniProfiler扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// add the middleware and configure options
        /// </summary>
        /// <param name="services"></param>
        public static void UseProfiler( this IServiceCollection services )
        {
            services.AddMiniProfiler( options =>
            {
                options.RouteBasePath = "/profiler";
            } );
            /*
             .AddMiniProfiler( options =>
        {
        // All of this is optional. You can simply call .AddMiniProfiler() for all defaults

        // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
        options.RouteBasePath = "/profiler";

        // (Optional) Control storage
        // (default is 30 minutes in MemoryCacheStorage)
        // Note: MiniProfiler will not work if a SizeLimit is set on MemoryCache!
        //   See: https://github.com/MiniProfiler/dotnet/issues/501 for details
        (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes( 60 );

        // (Optional) Control which SQL formatter to use, InlineFormatter is the default
        options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();

        // (Optional) To control authorization, you can use the Func<HttpRequest, bool> options:
        // (default is everyone can access profilers)
        options.ResultsAuthorize = request => MyGetUserFunction( request ).CanSeeMiniProfiler;
        options.ResultsListAuthorize = request => MyGetUserFunction( request ).CanSeeMiniProfiler;
        // Or, there are async versions available:
        options.ResultsAuthorizeAsync = async request => (await MyGetUserFunctionAsync( request )).CanSeeMiniProfiler;
        options.ResultsAuthorizeListAsync = async request => (await MyGetUserFunctionAsync( request )).CanSeeMiniProfilerLists;

        // (Optional)  To control which requests are profiled, use the Func<HttpRequest, bool> option:
        // (default is everything should be profiled)
        options.ShouldProfile = request => MyShouldThisBeProfiledFunction( request );

        // (Optional) Profiles are stored under a user ID, function to get it:
        // (default is null, since above methods don't use it by default)
        options.UserIdProvider = request => MyGetUserIdFunction( request );

        // (Optional) Swap out the entire profiler provider, if you want
        // (default handles async and works fine for almost all applications)
        options.ProfilerProvider = new MyProfilerProvider();

        // (Optional) You can disable "Connection Open()", "Connection Close()" (and async variant) tracking.
        // (defaults to true, and connection opening/closing is tracked)
        options.TrackConnectionOpenClose = true;

        // (Optional) Use something other than the "light" color scheme.
        // (defaults to "light")
        options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;

        // Optionally change the number of decimal places shown for millisecond timings.
        // (defaults to 2)
        options.PopupDecimalPlaces = 1;

        // The below are newer options, available in .NET Core 3.0 and above:

        // (Optional) You can disable MVC filter profiling
        // (defaults to true, and filters are profiled)
        options.EnableMvcFilterProfiling = true;
        // ...or only save filters that take over a certain millisecond duration (including their children)
        // (defaults to null, and all filters are profiled)
        // options.MvcFilterMinimumSaveMs = 1.0m;

        // (Optional) You can disable MVC view profiling
        // (defaults to true, and views are profiled)
        options.EnableMvcViewProfiling = true;
        // ...or only save views that take over a certain millisecond duration (including their children)
        // (defaults to null, and all views are profiled)
        // options.MvcViewMinimumSaveMs = 1.0m;

        // (Optional) listen to any errors that occur within MiniProfiler itself
        // options.OnInternalError = e => MyExceptionLogger(e);

        // (Optional - not recommended) You can enable a heavy debug mode with stacks and tooltips when using memory storage
        // It has a lot of overhead vs. normal profiling and should only be used with that in mind
        // (defaults to false, debug/heavy mode is off)
        //options.EnableDebugMode = true; )
    } );*/
        }

        /// <summary>
        /// Configure MiniProfiler with the options
        /// </summary>
        /// <param name="app"></param>
        public static void UseProfiler( this IApplicationBuilder app )
        {
            app.UseMiniProfiler();
        }
    }
}