using System;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp.Entries;
using System.Net.Http.Headers;

namespace Ban3.Infrastructures.NetHttp
{
    public static class Helper
    {
        public static HttpResponseMessage Request(this TargetHost host, TargetResource resource)
        {
            var client = host.Client();
            
            var result = client.SendAsync(resource.Request()).Result;
            
            client.Dispose();
            
            return result;
        }
    }
}
