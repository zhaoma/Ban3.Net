using System.Net;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static TargetResource Resource(this IRequest request)
    {
        return new TargetResource
        {
            Url = $"{request.RequestPath()}{request.RequestQuery()}",
            Method = request.Method,
            Body = new Body
            {
                StringContent = request.RequestBody()
            }
        };
    }

    public static async Task ExecuteVoid(this Enums.ServerResource resource, IRequest request)
    {
        var responseMessage = await Config.Host.Request(request.Resource());
        var content = responseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(request.Resource().Url);
        Logger.Debug(request.Resource().Url);
        Logger.Debug(content);
        Console.WriteLine($"responseMessage.StatusCode={responseMessage.StatusCode}");
        Console.WriteLine(content.Result);

        responseMessage.Dispose();
    }

    public static async Task<T> Execute<T>(this Enums.ServerResource resource, IRequest request)
        where T : IResponse,new()
    {
        var responseMessage =await Config.Host.Request(request.Resource());
        var content = responseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(request.Resource().Url);
        Logger.Debug(request.Resource().Url);
        Logger.Debug(content);
        Console.WriteLine($"responseMessage.StatusCode={responseMessage.StatusCode}");
        Console.WriteLine(content.Result);
        var result = content.Result.JsonToObj<T>()??new T();
        result.Success = new[]
        {
            HttpStatusCode.InternalServerError,
            HttpStatusCode.Accepted,
            HttpStatusCode.OK
        }.Contains(responseMessage.StatusCode);

        responseMessage.Dispose();
        return result;
    }

    public static async Task<string> ReadHtml(this Enums.ServerResource resource, IRequest request)
    {
        var responseMessage =await Config.Host.Request(request.Resource());
        Logger.Debug(request.Resource().Url);

        if (!new[]
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK
            }.Contains(responseMessage.StatusCode))
            return string.Empty;

        var result=await responseMessage.Content.ReadAsStringAsync();
        responseMessage.Dispose();
        return result;
    }

    public static async Task<string> Download(this Enums.ServerResource resource, IRequest request, string savePath)
    {
        var responseMessage =await Config.Host.Request(request.Resource());
        Logger.Debug(request.Resource().Url);
        Logger.Debug(savePath);

        if (!new[]
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK
            }.Contains(responseMessage.StatusCode))
            return string.Empty;

        var iputStream =await responseMessage.Content.ReadAsStreamAsync();

        await using var fileStream = File.Create(savePath);
        await iputStream.CopyToAsync(fileStream);

        responseMessage.Dispose();
        return savePath;
    }

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