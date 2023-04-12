/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            文档组件swagger
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Ban3.Infrastructures.Plugins.UtilizeSwagger
{
    /// <summary>
    /// 文档组件swagger扩展
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 将 Swagger 生成器添加到 Startup.ConfigureServices 方法中的服务集合中
        /// </summary>
        /// <param name="services"></param>
        public static void UseProfiler( this IServiceCollection services )
        {
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1", new OpenApiInfo { Title = "ban3API", Version = "v1" } );
            } );
        }

        /// <summary>
        /// 启用中间件为生成的 JSON 文档和 Swagger UI 提供服务
        /// </summary>
        /// <param name="app"></param>
        public static void UseProfiler( this IApplicationBuilder app )
        {
            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "ban3API V1" );
            } );
        }
    }
}