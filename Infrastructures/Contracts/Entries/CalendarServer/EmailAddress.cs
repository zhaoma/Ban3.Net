//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class EmailAddress:IEmailAddress
{
    public string Name { get; set; }

    public string Address { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    public EmailAddress()
    {
        Name = string.Empty;
        Address = string.Empty;
    }

    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="email"></param>
    /// <param name="name"></param>
    public EmailAddress(string email, string name)
    {
        Name = name;
        Address = email;
    }
}
