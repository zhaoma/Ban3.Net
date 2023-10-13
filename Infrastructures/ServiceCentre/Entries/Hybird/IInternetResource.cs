using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IInternetResource
{
    string Url { get; set; }

    string Method { get; set; }

    string Charset { get; set; }

    bool ResourceIsJsonp { get; set; }

    string JsonpPrefix { get; set; }

    Dictionary<string, string> Headers { get; set; }

    IInternetData Request { get; set; }
}