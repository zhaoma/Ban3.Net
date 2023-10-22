using System.IO;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 互联网数据声明
/// </summary>
public interface IInternetData
{
    /// <summary>
    /// 字节组
    /// </summary>
    byte[] Bytes { get; set; }

    /// <summary>
    /// 内容流
    /// </summary>
    Stream StreamContent { get; set; }

    /// <summary>
    /// 文本内容
    /// </summary>
    string StringContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string ContentMediaType { get; set; }

    string ContentEncoding { get; set; }
}