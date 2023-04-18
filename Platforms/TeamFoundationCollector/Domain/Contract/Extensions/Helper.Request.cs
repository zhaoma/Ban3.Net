using System.Net;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using System.Reflection;
using System.Xml.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

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

    public static T Execute<T>(this Enums.ServerResource resource, IRequest request) where T : IResponse
    {
        var responseMessage = Config.Host.Request(request.Resource());
        var content = responseMessage.Content.ReadAsStringAsync().Result;

        var result = content.JsonToObj<T>();
        result.Success = new[]
        {
            HttpStatusCode.Accepted,
            HttpStatusCode.OK
        }.Contains(responseMessage.StatusCode);

        return result;

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
}