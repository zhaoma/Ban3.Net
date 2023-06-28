using Ban3.Infrastructures.NetHttp.Request;
using System.Collections.Generic;
using System.Net.Http;

namespace Ban3.Infrastructures.NetHttp.Interfaces;

/// <summary>
/// 目标资源接口申明
/// </summary>
public interface ITargetResource
{
    string Url { get; set; }

    string Method { get; set; }

    string Charset { get; set; }

    bool ResourceIsJsonp { get; set; }

    string JsonpPrefix { get; set; }

    Dictionary<string, string> Headers { get; set; }

    Body Body { get; set; }

    HttpRequestMessage Request();

}

