﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp.Interfaces;

namespace Ban3.Infrastructures.NetHttp;

[TracingIt]
public static class Helper
{
    /// get resource response (void support too)
    public static async Task<HttpResponseMessage> Request(
        this ITargetHost host,
        ITargetResource resource,
        string accept = "")
    {
        try
        {
            var client = host.Client();
            if (!string.IsNullOrEmpty(accept))
                client.DefaultRequestHeaders.Add("Accept", accept);

            return await client.SendAsync(resource.Request());
        }
        catch (HttpRequestException ex)
            when (ex.InnerException is OperationCanceledException tex)
        {
            Console.WriteLine(tex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
    }

    /// get resource content
    public static async Task<string> ReadContent(
        this ITargetHost host,
        ITargetResource resource,
        string accept = "")
    {
        using var responseMessage = await host.Request(resource, accept);

        return await responseMessage.Content.ReadAsStringAsync();
    }

    /// 
    public static async Task<byte[]> ReadBytes(
        this ITargetHost host,
        ITargetResource resource)
    {
        using var responseMessage = await host.Request(resource);

        return await responseMessage.Content.ReadAsByteArrayAsync();
    }

    /// get resource content and deserialize to special type
    public static async Task<T> RequestGeneric<T>(
        this ITargetHost host,
        ITargetResource resource)
    {
        var content = await host.ReadContent(resource);

        if (resource.ResourceIsJsonp)
        {
            content = content.RemoveJsonpTags(resource.JsonpPrefix);
        }

        return content.JsonToObj<T>();
    }

    /// download resource and save to special path
    public static async Task<string> Download(
        this ITargetHost host,
        ITargetResource resource,
        string savePath)
    {
        using var responseMessage = await host.Request(resource);

        using var inputStream = await responseMessage.Content.ReadAsStreamAsync();

        using var fileStream = File.Create(savePath);

        await inputStream.CopyToAsync(fileStream);

        return savePath;
    }
}