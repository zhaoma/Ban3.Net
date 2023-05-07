/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            服务平台接口实现（Eastmoney）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Sites.ViaEastmoney.Entries;
using Ban3.Sites.ViaEastmoney.Request;
using Ban3.Sites.ViaEastmoney.Response;
using log4net;

namespace Ban3.Sites.ViaEastmoney
{
    /// <summary>
    /// Eastmoney平台接口实现
    /// </summary>
    public static class Helper
    {
        private readonly ILog _logger;
        private readonly IDataCollection _collector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="collector"></param>
        /// <param name="fileStorage"></param>
        public Service(
            ILog logger, 
            IDataCollection collector)
        {
            _logger = logger;
            _collector = collector;
        }

        /// <summary>
        /// 下载所有标的代码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DownloadAllCodesResult DownloadAllCodes()
        {
            var request = new DownloadAllCodes();

            var package=_collector
                .Get<StockCodesPackage>(request.NetResource());

            return new DownloadAllCodesResult { Data = package };
        }
    }
}