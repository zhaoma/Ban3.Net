/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma @ 2022 :
 * RabbitMQ服务器访问接口实现
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Text;

using log4net;

using RabbitMQ.Client;

namespace Ban3.Infrastructures.Particulars.UtilizeRabbitMQ
{
    /// <summary>
    /// RabbitMQ服务器访问接口实现
    /// </summary>
    public class Service
            : Interfaces.Particulars.IRabbitMQ
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

        internal static readonly Common.Settings.Particulars.RabbitMQConfig Config
                = Common.Config.CurrrentEnvironment.Particulars.RabbitMQ;

        internal static readonly object Locker = new object();
        internal static ConnectionFactory _instance;

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        _instance = new ConnectionFactory
                        {
                            HostName = Config.HostName,
                            UserName = Config.UserName,
                            Password = Config.Password,

                            RequestedHeartbeat = new TimeSpan(0),
                            AutomaticRecoveryEnabled = true,
                        };
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="props"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public bool BasicPublish(PublicationAddress addr, IBasicProperties props, byte[] body)
        {
            try
            {
                using (var conn = Instance.CreateConnection())
                {
                    using (var model = conn.CreateModel())
                    {
                        model.BasicPublish(addr, props, body);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="routingKey"></param>
        /// <param name="props"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public bool BasicPublish(string exchange, string routingKey, IBasicProperties props, byte[] body)
        {
            try
            {
                using (var conn = Instance.CreateConnection())
                {
                    using (var model = conn.CreateModel())
                    {
                        model.BasicPublish(exchange, routingKey, props, body);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchange"></param>
        /// <param name="routingKey"></param>
        /// <param name="mandatory"></param>
        /// <param name="props"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public bool BasicPublish(string exchange, string routingKey, bool mandatory, IBasicProperties props, byte[] body)
        {
            try
            {
                using var conn = Instance.CreateConnection();
                using var model = conn.CreateModel();
                model.BasicPublish(exchange, routingKey, mandatory, props, body);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ClientSend(string message)
        {
            try
            {
                using var conn = Instance.CreateConnection();
                using var model = conn.CreateModel();
                //model.ExchangeDeclare(Config.ExchangeName, "direct", true, false);
                //model.QueueDeclare(Config.ChannelName, durable: true, autoDelete: false, exclusive: false, arguments: null);
                //model.QueueBind(Config.ChannelName, Config.ExchangeName, routingKey: Config.RoutingKeyFromClient);

                var props = model.CreateBasicProperties();

                model.BasicPublish(
                                   Config.ExchangeName,
                                   Config.RoutingKey,
                                   true,
                                   props,
                                   Encoding.UTF8.GetBytes(message));

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }
    }
}