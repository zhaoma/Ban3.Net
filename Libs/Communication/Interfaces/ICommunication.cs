/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            设备连接接口申明
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Communication.Interfaces
{
    public interface ICommunication
    {
        /// <summary>
        /// 连接状态
        /// </summary>
        bool Connected { get; set; }

        /// <summary>
        /// 收到数据事件
        /// </summary>
        event DataHandle<byte[]> BytesReceived;

        /// <summary>
        /// 开始使用
        /// </summary>
        /// <returns></returns>
        bool Start();

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Send(byte[] data);

        /// <summary>
        /// 停止使用
        /// </summary>
        void Stop();

    }
    
    public delegate void DataHandle<T>(T data);
}
