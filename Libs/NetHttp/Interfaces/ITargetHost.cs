using System;
using System.Net.Http;

namespace Ban3.Infrastructures.NetHttp.Interfaces;

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

