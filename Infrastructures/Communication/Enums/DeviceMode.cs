/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            设备连接方式
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.ComponentModel;

namespace Ban3.Infrastructures.Communication.Enums
{
    /// <summary>
    /// 设备连接模式
    /// </summary>
    public  enum DeviceMode
    {
        /// <summary>
        /// TCP连接
        /// </summary>
        [Description("TCP连接")]
        Tcp,

        /// <summary>
        /// UDP连接
        /// </summary>
        [Description("UDP连接")]
        Udp,

        /// <summary>
        /// SOCKET连接
        /// </summary>
        [Description("SOCKET连接")]
        Socket,

        /// <summary>
        /// 串口连接
        /// </summary>
        [Description("串口连接")]
        SerialPort
    }
}
