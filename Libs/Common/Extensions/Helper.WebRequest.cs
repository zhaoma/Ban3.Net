using System;
using System.IO;
using System.Net;
using System.Text;

namespace Quick.Portal.Utility.Common
{
    /// <summary>
    /// 远程读取处理类
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 实例化一个远程地址
        /// </summary>
        /// <param name="uri">远程地址</param>
        public static HttpWebResponse Execute(this HttpWebRequest request)
        {
            return (HttpWebResponse)(request.GetResponse());
        }
    }
}
