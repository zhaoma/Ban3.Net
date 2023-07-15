using System.IO;
using System.Net.Http;
using System.Text;

namespace Ban3.Infrastructures.NetHttp.Request;

/// <summary>
/// 请求体
/// </summary>
public class Body
{
    /// <summary>
    /// 发送字节组
    /// </summary>
    public byte[] Bytes { get; set; }

    /// <summary>
    /// 发送流
    /// </summary>
    public Stream StreamContent { get; set; }

    /// <summary>
    /// 发送文本
    /// </summary>
    public string StringContent { get; set; } = string.Empty;

    /// <summary>
    /// 媒体类型
    /// </summary>
    public string ContentMediaType { get; set; } = "application/json";

    /// <summary>
    /// 编码
    /// </summary>
    public string ContentEncoding { get; set; } = "utf-8";

    /// <summary>
    /// 转HttpContent
    /// </summary>
    /// <returns></returns>
    public HttpContent Content()
    {
        if (Bytes != null)
            return new ByteArrayContent(Bytes);

        if (StreamContent != null)
            return new StreamContent(StreamContent);

        if (!string.IsNullOrEmpty(StringContent))
            return new StringContent(StringContent, Encoding.GetEncoding(ContentEncoding), ContentMediaType);

        return null;
    }
}
