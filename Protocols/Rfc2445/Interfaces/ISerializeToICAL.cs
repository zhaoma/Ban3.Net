using System.IO;

namespace Ban3.Protocols.Rfc2445.Interfaces
{
    /// <summary>
    /// 可序列化对象接口定义
    /// </summary>
    public interface ISerializeToICAL
    {
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="serializer"></param>
        void Deserialize( TextReader rdr, Serializer serializer );

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="wrtr"></param>
        void Serialize( TextWriter wrtr );
    }
}