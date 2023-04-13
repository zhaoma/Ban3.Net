using System;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Infrastructures.NetHttp
{
    public static class Helper
    {
        public static Task<HttpResponseMessage> Send(this TargetHost host, TargetResource resource)
        {
            var client = host.Client();

            var result= client.SendAsync(resource.Request());
            //client.Dispose();

            return result;
        }

        public static Task<string> GetString(this TargetHost host, TargetResource resource)
        {
            var client = host.Client();

            var result = client.GetStringAsync(resource.Url);

            result.EnsureSuccessStatusCode.
            //client.Dispose();

            return result;
        }
    }
}
