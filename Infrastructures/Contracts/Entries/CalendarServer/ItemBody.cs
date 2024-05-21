//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 
/// </summary>
public class ItemBody : IItemBody
{
    public ItemBody(string content) { Content=content; }

    public ItemBody(string content, BodyType bodyType)
    {
        Content = content;
        ContentType = bodyType;
    }

    public BodyType ContentType { get; set; } = BodyType.Html;

    public string Content { get; set; } = string.Empty;
}
