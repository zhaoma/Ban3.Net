using System.IO;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Sites.ViaYuncaijing.Entries;
using Ban3.Sites.ViaYuncaijing.Request;
using Ban3.Sites.ViaYuncaijing.Response;
using log4net;

namespace Ban3.Sites.ViaYuncaijing
{
    public static class Helper
    {
        static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

        /// <summary>
        /// 解析出地址,并下载到本地
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<DownloadOneIconResult> DownloadOneIcon(DownloadOneIcon request)
        {
            var host = new TargetHost
            {
                Anonymous = true
            };
            var html = await host.ReadContent(request);

            var imgAddress = html.FirstHtmlImage("stock-logo");

            var savePath = string.Empty;

            if (!string.IsNullOrEmpty(imgAddress))
            {
                savePath = typeof(Icon).LocalFile(request.Code,Path.GetExtension(imgAddress));
                savePath = await host.Download(new TargetResource { Url = imgAddress }, savePath);
            }
            
            return new DownloadOneIconResult { Path = savePath };
        }
    }
}
