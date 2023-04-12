/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            服务平台接口实现（Google）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Sites.ViaGtimg.Request;
using log4net;

namespace Ban3.Sites.ViaGtimg
{
    /// <summary>
    /// Google平台接口实现
    /// </summary>
    public class Service
        :Interfaces.Platforms.IGtimg
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

        public ReadBidAndAskResult ReadBidAndAsk(ReadBidAndAsk request)
        {

            return (ReadBidAndAskResult)_collector
                .GetCallback<StockCodesPackage>(request.NetResource());
        }

        public ReadBriefResult ReadBrief(ReadBrief request)
        {

        }
    }
}
