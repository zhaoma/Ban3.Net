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
        public static async Task<HttpResponseMessage> Request(this TargetHost host, TargetResource resource)
        {
            var client = host.Client();
            
            return await client.SendAsync(resource.Request());
        }
    }
}
