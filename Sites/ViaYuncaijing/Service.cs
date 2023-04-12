using System;
using Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Yuncaijing;
using Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Yuncaijing;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Interfaces;
using log4net;

namespace Ban3.Infrastructures.Platforms.ViaYuncaijing
{
    public class Service
        : Interfaces.Platforms.IYuncaijing
    {
        private readonly ILog _logger;
        private readonly IDataCollection _collector;

        /// 
        public Service(ILog logger, IDataCollection collector)
        {
            _logger = logger;
            _collector = collector;
        }

        /// <summary>
        /// 只解析出地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DownloadOneIconResult DownloadOneIcon(DownloadOneIcon request)
        {
            _logger.Debug($"DownloadOneIcon:{request.Code}");

            var html = _collector.GetContent(request.NetResource());

            var imgAddress = html.FirstHtmlImage("stock-logo");

            return new DownloadOneIconResult { Data = imgAddress };
        }
    }
}
