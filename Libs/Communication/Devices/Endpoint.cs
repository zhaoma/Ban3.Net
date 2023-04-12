using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Ban3.Infrastructures.Communication.Devices
{
    /// <summary>
    /// 设备端点
    /// </summary>
    public class Endpoint
    {
        public Endpoint() { }

        /// <summary>
        /// 设备模式
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Enums.DeviceMode Mode { get; set; }

        #region IP AND PORT
        
        /// <summary>
        /// 设备地址
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IP { get; set; }

        /// <summary>
        /// 设备端口
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Port { get; set; }

        /// <summary>
        /// 发送超时
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int SendTimeout { get; set; } = 2000;

        /// <summary>
        /// 接收超时
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ReceiveTimeout { get; set; } = 2000;

        /// <summary>
        /// 接收缓冲区
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ReceiveBufferSize { get; set; } = 8192;

        /// <summary>
        /// 发送缓冲区
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int SendBufferSize { get; set; } = 1024;

        public Endpoint(Enums.DeviceMode mode,string ip,int port)
        {
            Mode= mode;
            IP = ip;
            Port = port;
        }

        public IPAddress IPAddress()
        {
            if (!string.IsNullOrEmpty(IP))
                return System.Net.IPAddress.Parse(IP);

            return null;
        }

        #endregion

        #region PortName AND Baud

        public Endpoint(Enums.DeviceMode mode, string portName)
        {
            Mode = mode;
            PortName = portName;
        }

        /// <summary>
        /// 串口名
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PortName { get; set; }

        /// <summary>
        /// 串口波特率
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int BaudRate { get; set; } = 9600;

        /// <summary>
        /// 数据位
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int DataBits { get; set; } = 8;

        /// <summary>
        /// 停止位
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public System.IO.Ports.StopBits StopBits { get; set; } 
            = System.IO.Ports.StopBits.One;

        /// <summary>
        /// 校验位
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public System.IO.Ports.Parity Parity { get; set; } 
            = System.IO.Ports.Parity.None;

        /// <summary>
        /// 握手
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public System.IO.Ports.Handshake Handshake { get; set; }
            = System.IO.Ports.Handshake.None;

        #endregion
    }
}
