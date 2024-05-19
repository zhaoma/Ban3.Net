//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials;
using System;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

[Serializable, DataContract]
public class ItemBody : IItemBody
{
    public BodyType ContentType { get; set; } = BodyType.Html;

    public string Content { get; set; } = string.Empty;
}
