/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            TCP通讯
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
    public class TcpAgency
        : ICommunication, IDisposable
    {
        private ILog _logger = LogManager.GetLogger(typeof(TcpAgency));

        #region 构造

        private TcpClient _tcpClient=null;

        private NetworkStream _stream = null;
        private Endpoint _endpoint { get; set; }

        private Thread _receiveThread;

        public TcpAgency() { }

        public TcpAgency(Endpoint ep)
        {
            _endpoint = ep;
        }

        #endregion
        public bool Connected { get; set; }

        public event DataHandle<byte[]> BytesReceived;

        /// <summary>
        /// 
        /// </summary>
        public bool Start()
        {
            try
            {
                if (_tcpClient == null)
                {
                    _tcpClient = new TcpClient();
                }

                if (!Connected)
                {
                    _logger.Debug($"!Connected{_endpoint.IP}");
                    /*
                    _tcpClient.SendTimeout = _endpoint.SendTimeout;
                    _tcpClient.ReceiveTimeout = _endpoint.ReceiveTimeout;
                    _tcpClient.SendBufferSize = _endpoint.SendBufferSize;
                    _tcpClient.ReceiveBufferSize = _endpoint.ReceiveBufferSize;
                    */
                    _tcpClient.Connect(_endpoint.IPAddress(), _endpoint.Port);
                    _stream = _tcpClient.GetStream();

                    Connected = true;
                    _logger.Debug($"_tcpClient.Connected={_tcpClient.Connected}");
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
            }catch(Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        public bool Send(byte[] data)
        {
            try
            {
                if (_tcpClient != null && Connected)
                {
                    //_stream = _tcpClient.GetStream();
                    lock (_stream)
                    {
                        _stream.Write(data, 0, data.Length);
                    return true;
                    }

                }
            }catch(Exception ex)
            {
                _logger.Error("SEND");
                _logger.Error(ex);
            }

            return false;
        }
        private bool StopThread { get; set; } = false;
        private void ReceiveData()
        {
            while (!StopThread)
            {
                try
                {
                    var buffer = new byte[_tcpClient.ReceiveBufferSize];

                    var len=_stream.Read(buffer, 0, buffer.Length);
                    if (len == 0)
                        continue;

                    if (BytesReceived != null)
                    {
                        var r= new byte[len];
                        Array.Copy(buffer, r, len);
                        BytesReceived(r);
                    }
                }catch(Exception ex)
                {
                    _logger.Error("RECEIVE");
                    _logger.Error(ex);
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
            if (_stream != null) { _stream.Dispose(); }

            if (_tcpClient != null)
            {
                _tcpClient.Close();
                Connected = false;
                _tcpClient = null;
            }
        }

    }
}
