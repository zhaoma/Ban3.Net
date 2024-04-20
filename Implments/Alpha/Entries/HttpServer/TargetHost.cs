//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components.Entries.HttpServer;

namespace Ban3.Implements.Alpha.Entries.HttpServer;

public class TargetHost:IHost
{
    public bool Anonymous { get; set; } = false;

    public string BaseUrl { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Domain { get; set; } = string.Empty;

    public string AuthenticationType { get; set; } = "Basic";
}
