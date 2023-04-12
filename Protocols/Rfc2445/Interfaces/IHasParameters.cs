using System.Collections.Specialized;

namespace Ban3.Protocols.Rfc2445.Interfaces
{
    /// <summary>
    /// 有参数类接口定义
    /// </summary>
    public interface IHasParameters
    {
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <returns></returns>
        NameValueCollection GetParameters();

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameters"></param>
        void Deserialize( string value, NameValueCollection parameters );
    }
}