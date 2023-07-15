/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            UDP通讯
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using log4net;
using System;
using System.Net.Sockets;
using System.Threading;
using Ban3.Infrastructures.Communication.Interfaces;

namespace Ban3.Infrastructures.Communication.Devices
{
    /// <summary>
    /// 
    /// </summary>
    public class UdpAgency
        : ICommunication, IDisposable
    {
        private ILog _logger = LogManager.GetLogger(typeof(TcpAgency));

        #region 构造

        private TcpClient? _udpClient=null;

        private Endpoint? _endpoint { get; set; }

        private Thread _receiveThread;

        /// <summary>
        /// 
        /// </summary>
        public UdpAgency() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ep"></param>
        public UdpAgency(Endpoint ep)
        {
            _endpoint = ep;
        }

        /// <summary>
        /// 
        /// </summary>
        #endregion
        public bool Connected
        {
            get;set;
        }

        /// <summary>
        /// 
        /// </summary>
        public event DataHandle<byte[]> BytesReceived;

        /// <summary>
        /// 
        /// </summary>
        public bool Start()
        {
            try
            {
                if (_udpClient == null)
                {
                    _udpClient = new TcpClient();
                }

                if (!Connected)
                {
                    _udpClient.SendTimeout = _endpoint.SendTimeout;
                    _udpClient.ReceiveTimeout = _endpoint.ReceiveTimeout;
                    _udpClient.SendBufferSize = _endpoint.SendBufferSize;
                    _udpClient.ReceiveBufferSize = _endpoint.ReceiveBufferSize;

                    _udpClient.Connect(_endpoint.IPAddress(), _endpoint.Port);
                    Connected = true;
                }

                if (_receiveThread == null)
                {
                    _receiveThread = new Thread(new ThreadStart(ReceiveData))
                    {
                        IsBackground = true,
                    };
                }

                if (_receiveThread.ThreadState != ThreadState.Running)
                {
                    StopThread = false;
                    _receiveThread.Start();
                }

                return true;
            }catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Send(byte[] data)
        {
            try
            {
                if (_udpClient != null && _udpClient.Connected)
                {
                    var sendStream = _udpClient.GetStream();
                    sendStream.Write(data, 0, data.Length);
                    sendStream.Flush();
                    sendStream.Close();

                    return true;
                }
            }catch(Exception ex)
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
                var buffer = new byte[_udpClient.ReceiveBufferSize];

                var receivedStream = _udpClient.GetStream();
                receivedStream.Read(buffer, 0, buffer.Length);
                receivedStream.Close();

                if (BytesReceived != null)
                {
                    BytesReceived(buffer);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            StopThread = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_udpClient != null)
            {
                _udpClient.Close();
                _udpClient = null;

                Connected = false;
            }
        }

    }
}
