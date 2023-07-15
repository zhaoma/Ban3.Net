/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            Socket通讯
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using log4net;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Ban3.Infrastructures.Communication.Interfaces;

namespace Ban3.Infrastructures.Communication.Devices
{

    /// <summary>
    /// Socket客户端
    /// </summary>
    public class SocketAgency
        : ICommunication, IDisposable
    {
        private ILog _logger = LogManager.GetLogger(typeof(SocketAgency));

        #region 构造
        private Socket _socket = null;

        private Endpoint _endpoint { get; set; }

        private Thread _receiveThread;

        /// ctor
        public SocketAgency()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ep">目标终端</param>
        public SocketAgency(Endpoint ep)
        {
            _endpoint = ep;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public bool Connected
        {
            get;set;
        }

        public event DataHandle<byte[]> BytesReceived;

        /// <summary>
        /// 打开Socket
        /// </summary>
        public bool Start()
        {
            try
            {
                if (_socket == null)
                {
                    _socket = new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.Tcp);
                }

                if (!Connected)
                {
                    _socket.SendTimeout = _endpoint.SendTimeout;
                    _socket.ReceiveTimeout = _endpoint.ReceiveTimeout;
                    _socket.SendBufferSize = _endpoint.SendBufferSize;
                    _socket.ReceiveBufferSize = _endpoint.ReceiveBufferSize;

                    var endPoint = new IPEndPoint(_endpoint.IPAddress(), _endpoint.Port);
                    _socket.Connect(endPoint);

                    Connected = true;
                }

                if (_receiveThread == null)
                {
                    _receiveThread = new Thread(new ThreadStart(ReceiveData))
                    {
                        IsBackground = true
                    };
                }

                if (_receiveThread.ThreadState != ThreadState.Running)
                {
                    StopThread = false;
                    _receiveThread.Start();
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
        /// 发送指令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Send(byte[] data)
        {
            try
            {
                _socket.Send(data);

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        private bool StopThread { get; set; } = false;
        private void ReceiveData()
        {
            while (!StopThread)
            {
                var buffer = new byte[1024];
                try
                {
                    _socket.Blocking = true;
                    var length = _socket.Receive(buffer);

                    if (length == 0)
                        continue;

                    if (BytesReceived != null)
                    {
                        BytesReceived(buffer);
                    }
                }
                catch (SocketException ex)
                {
                    _logger.Error(ex);
                }
            }
        }


        /// <summary>
        /// 关闭Socket
        /// </summary>
        public void Stop()
        {
            try
            {
                _logger.Debug("Close");
                StopThread = true;

                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_socket != null)
            {
                _socket = null;
            }

            Connected = false;
        }
    }
}
