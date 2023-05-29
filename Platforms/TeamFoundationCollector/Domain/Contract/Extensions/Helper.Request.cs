using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Infrastructures.Common.Extensions;
using System.Linq;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static TargetResource Resource(this IRequest request)
    {
        var query = request.RequestQuery();
        if (query == "?")
            query = "";
        return new TargetResource
        {
            Url = $"{request.RequestPath()}{query}",
            Method = request.Method,
            Body = new Body
            {
                StringContent = request.RequestBody()
            }
        };
    }

    public static async Task ExecuteVoid(this Enums.ServerResource resource, IRequest request)
    {
        try
        {
            using var responseMessage = await Config.Host.Request(request.Resource());
        }
        catch (Exception ex)
        {
            Logger.Error(request.Resource().Url);
            Logger.Error(ex);
        }
    }

    public static async Task<T> Execute<T>(this Enums.ServerResource resource, IRequest request)
        where T : IResponse, new()
    {
        try
        {
            var responseMessage = await Config.Host.Request(request.Resource());
            if (responseMessage == null) return new T();

            var content = responseMessage.Content.ReadAsStringAsync();

            var result = content.Result.JsonToObj<T>() ?? new T();
            result.Success = new[]
            {
                HttpStatusCode.InternalServerError,
                HttpStatusCode.Accepted,
                HttpStatusCode.OK
            }.Contains(responseMessage.StatusCode);

            responseMessage.Dispose();
            return result;
        }
        catch (Exception ex)
        {
            Logger.Error(request.Resource().Url);
            Logger.Error(ex);
        }

        return new T();
    }

    public static async Task<string> ReadHtml(this Enums.ServerResource resource, IRequest request, string accept = "")
        => await Config.Host.ReadContent(request.Resource(), accept);

    public static async Task<string> Download(this Enums.ServerResource resource, IRequest request, string savePath)
        => await Config.Host.Download(request.Resource(), savePath);

    /*
    var field = resource.GetType().GetField(resource.ToString())!;
    var declare = field.GetCustomAttribute(typeof(ResourceDeclareAttribute), false);

    if (declare != null)
    {
        var resourceDeclare = declare as ResourceDeclareAttribute;

        var responseMessage = Config.Host.Request(request.Resource());
        var content = responseMessage.Content.ReadAsStringAsync().Result;

        var result = content.JsonToObj<T>();
        result.Success = new[]
        {
            HttpStatusCode.Accepted,
            HttpStatusCode.OK
        }.Contains(responseMessage.StatusCode);

        return result;
    }

    return default(T);
    */
}