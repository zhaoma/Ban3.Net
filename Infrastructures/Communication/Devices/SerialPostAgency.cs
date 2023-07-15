/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            串口通讯
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using log4net;
using System;
using System.Threading;
using Ban3.Infrastructures.Communication.Interfaces;

namespace Ban3.Infrastructures.Communication.Devices
{
    /// <summary>
    /// 串口设备
    /// </summary>
    public class SerialPortAgency
        :ICommunication, IDisposable
    {

        private ILog _logger = LogManager.GetLogger(typeof(SerialPortAgency));

        /// <summary>
        /// 串口
        /// </summary>
        public System.IO.Ports.SerialPort _serialPort { get; set; }

        private Endpoint _endpoint { get; set; }

        public SerialPortAgency() { }

        /// <summary>
        /// 门锁与灯控制板的波特率与参数固定
        /// </summary>
        /// <param name="portName"></param>
        public SerialPortAgency(Endpoint ep)
        {
            _endpoint = ep;
        }
        public bool Connected
        {
            get;set;
        }

        public event DataHandle<byte[]> BytesReceived;
        public bool Start()
        {
            try
            {
                _logger.Debug($"打开端口{_endpoint.PortName}");
                _serialPort = new System.IO.Ports.SerialPort(_endpoint.PortName)
                {
                    BaudRate = _endpoint.BaudRate,
                    DataBits = _endpoint.DataBits,
                    StopBits = _endpoint.StopBits,
                    Parity = _endpoint.Parity,
                    Handshake = _endpoint.Handshake
                };
                _serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived);
                _serialPort.Open();

                Connected = true;

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }
        public bool Send(byte[] data)
        {
            try
            {
                _serialPort.Write(data, 0, data.Length);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return false;
        }

        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(50);
                _logger.Debug($"{_serialPort.PortName}收到数据");
                var receivedData = new byte[_serialPort.BytesToRead];
                _serialPort.Read(receivedData, 0, receivedData.Length);

                BytesReceived(receivedData);
                _serialPort.DiscardInBuffer();

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public void Stop()
        {
            try
            {
                _serialPort.Close(); Connected = false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
        public void Dispose()
        {
            if (_serialPort != null)
            {
                Stop();
                _serialPort = null;
            }
        }
    }
}
