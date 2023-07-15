using System.Net.Http;

namespace Ban3.Infrastructures.NetHttp.Interfaces;

/// <summary>
/// 目标主机接口申明
/// </summary>
public interface ITargetHost
{
    bool Anonymous { get; set; }

    string BaseUrl { get; set; }

    string UserName { get; set; }

    string Password { get; set; }

    string Domain { get; set; }

    string AuthenticationType { get; set; }

    HttpClient Client();
}

