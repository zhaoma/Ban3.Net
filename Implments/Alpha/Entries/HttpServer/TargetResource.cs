//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components.Entries.HttpServer;
using System.Collections.Generic;
using System.IO;

namespace Ban3.Implements.Alpha.Entries.HttpServer;

public class TargetResource:IResource
{
    public string Url { get; set; } = string.Empty;

    public string Method { get; set; } = "Get";

    public string Charset { get; set; }

    public bool ResourceIsJsonp { get; set; } 

    public string JsonpPrefix { get; set; } 

    public Dictionary<string, string> Headers { get; set; } 

    public byte[] Bytes { get; set; }

    public Stream StreamContent { get; set; }

    public string StringContent { get; set; } 

    public string ContentMediaType { get; set; } = "application/json";

    public string ContentEncoding { get; set; } = "utf-8";
}
