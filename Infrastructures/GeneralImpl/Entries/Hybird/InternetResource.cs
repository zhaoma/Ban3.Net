//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Hybird;

public class InternetResource : OneObject, IInternetResource
{
    public InternetResource() {}

    public string Url { get; set; }

    public HttpMethod Method { get; set; }

    public string Charset { get; set; }

    public string Accept { get; set; }

    public bool IsJsonp { get; set; }

    public string JsonpPrefix { get; set; }

    public IDictionary<string, string> Headers { get; set; }

    public IInternetData Request { get; set; }

    public IDictionary<string, string> Query { get; set; }
}