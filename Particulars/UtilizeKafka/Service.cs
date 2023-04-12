/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * KAFKA服务器访问接口实现
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Interfaces.Particulars;
using log4net;

namespace Ban3.Infrastructures.Particulars.UtilizeKafka
{
    public class Service
            : IKafka
    {
        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Service(ILog logger)
        {
            _logger = logger;
        }

    }
}