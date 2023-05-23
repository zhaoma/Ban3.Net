using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp.Interfaces;
using log4net;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.NetHttp;

public static class Helper
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    /// get resource response (void support too)
    public static async Task<HttpResponseMessage> Request(
        this ITargetHost host,
        ITargetResource resource,
        string accept="")
    {
        try
        {
            Logger.Debug(resource.Url);
            var client = host.Client();
            if(!string.IsNullOrEmpty(accept))
                client.DefaultRequestHeaders.Add("Accept", accept);
            
            return await client.SendAsync(resource.Request());
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    /// get resource content
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

    public static async Task<byte[]> ReadBytes(
        this ITargetHost host,
        ITargetResource resource)
    {
        try
        {

            using var responseMessage = await host.Request(resource);

            return await responseMessage.Content.ReadAsByteArrayAsync();
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    /// get resource content and deserialize to special type
    public static async Task<T> RequestGeneric<T>(
        this ITargetHost host,
        ITargetResource resource)
    {
        try
        {
            var content = await host.ReadContent(resource);

            if (resource.ResourceIsJsonp)
            {
                content = content.RemoveJsonp(resource.JsonpPrefix);
            }

            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return default;
    }

    #region private

    private static string Substr(this string input, string prefix, string suffix)
    {
        if (!input.Contains(prefix)) return string.Empty;

        var start = input.IndexOf(prefix) + prefix.Length;
        var result = input.Substring(start);

        if (!result.Contains(suffix)) return result;
        return result.Substring(0, result.Length - suffix.Length);
    }

    private static string RemoveJsonp(this string input, string jsonp)
        => input.Substr($"{jsonp}(", ");");


    #endregion

    /// download resource and save to special path
    public static async Task<string> Download(
        this ITargetHost host,
        ITargetResource resource,
        string savePath)
    {
        try
        {
            using var responseMessage = await host.Request(resource);

            using var inputStream = await responseMessage.Content.ReadAsStreamAsync();

            using var fileStream = File.Create(savePath);

            await inputStream.CopyToAsync(fileStream);

            return savePath;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return string.Empty;
    }
}