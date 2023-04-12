/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * 意外处理中间件
 * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Net;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Contracts = Ban3.Infrastructures.Common.Contracts;

namespace Ban3.Infrastructures.AspectOriented.Middlewares
{
    /// <summary>
    /// 意外处理中间件
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="next"></param>
        public ExceptionHandlerMiddleware(
                ILog logger,
                RequestDelegate next )
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke( HttpContext context )
        {
            try
            {
                await _next( context );
            }
            catch( Exception ex )
            {
                await HandleExceptionAsync( context, ex );
            }
        }

        private async Task HandleExceptionAsync( HttpContext context, Exception ex )
        {
            if( ex == null ) return;

            _logger.Error( ex);

            await WriteExceptionAsync( context, ex ).ConfigureAwait( false );
        }

        private static async Task WriteExceptionAsync( HttpContext context, Exception e )
        {
            if( e is UnauthorizedAccessException )
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if( e is Exception )
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";

            var response = new Contracts.Responses.Result(Contracts.Enums.ResponseStatusCode.Code500, e.Message );

            await context.Response.WriteAsync( response.ObjToJson() ).ConfigureAwait( false );
        }
    }
}