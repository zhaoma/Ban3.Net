//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 渠道，live/google/icalDAV/etc.
/// </summary>
public class Channel : IZero
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 服务器地址
    /// </summary>
    public string ChannelUrl { get; set; }

    /// <summary>
    /// 应用ID
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 应用Secret
    /// </summary>
    public string AppSecret { get; set; }

    /// <summary>
    /// 应用Key
    /// </summary>
    public string AppKey { get; set; }

    /// <summary>
    /// 回叫地址
    /// </summary>
    public string CodeCallback { get; set; }

    /// <summary>
    /// 渠道参数
    /// </summary>
    public string Parameters { get; set; }

    /// <summary>
    /// CalDav服务器
    /// </summary>
    public string CalDavServer { get; set; }
}
