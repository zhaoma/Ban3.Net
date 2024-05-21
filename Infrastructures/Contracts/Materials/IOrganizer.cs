//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

public interface IOrganizer : IZero
{
    /// <summary>
    /// 显示名称
    /// </summary>
    string DisplayName { get; set; }

    /// <summary>
    /// 邮件
    /// </summary>
    string Email { get; set; }

    /// <summary>
    /// 配置文件ID
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// 是自己
    /// </summary>
    bool Self { get; set; }

    /// <summary>
    /// 邮箱(MS)
    /// </summary>
    IEmailAddress? EmailAddress { get; set; }
}
