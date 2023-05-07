using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Infrastructures.NetHttp.Interfaces;
using log4net;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.NetHttp;

public static class Helper
{
    private static ILog Logger = LogManager.GetLogger(typeof(Helper));

    public static async Task<HttpResponseMessage> Request(
	this ITargetHost host, 
    ITargetResource resource)
    {
        try
        {
            var client = host.Client();

            return await client.SendAsync(resource.Request());
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    public static async Task<string> ReadContent(
	this ITargetHost host,
     ITargetResource resource)
    {
        try
        {
            using var responseMessage = await host.Request(resource);

            return await responseMessage.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return string.Empty;
    }

    public static async Task<T> RequestGeneric<T>(
	this ITargetHost host, 
    ITargetResource resource)
    {
        try
        {
            var content = await host.ReadContent(resource);

            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="resource"></param>
    /// <param name="savePath"></param>
    /// <returns></returns>
    public static async Task<string> Download(
    this ITargetHost host,
    ITargetResource resource,
    string savePath)
    {
        try
        {
            using var responseMessage = await host.Request(resource);

            var iputStream = await responseMessage.Content.ReadAsStreamAsync();

            using FileStream fileStream = File.Create(savePath);

            await iputStream.CopyToAsync(fileStream);

            return savePath;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return string.Empty;
    }

}