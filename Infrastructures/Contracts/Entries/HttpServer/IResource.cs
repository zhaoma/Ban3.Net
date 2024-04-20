//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using System.IO;

namespace Ban3.Infrastructures.Components.Entries.HttpServer;

/// <summary>
/// HTTP请求资源
/// </summary>
public interface IResource
{
    string Url { get; set; }

    string Method { get; set; }

    string Charset { get; set; }

    bool ResourceIsJsonp { get; set; }

    string JsonpPrefix { get; set; }

    Dictionary<string, string> Headers { get; set; }

    byte[] Bytes { get; set; }

    Stream StreamContent { get; set; }

    string StringContent { get; set; }

    string ContentMediaType { get; set; }

    string ContentEncoding { get; set; }
}
