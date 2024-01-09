//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Common;

/// <summary>
/// 内容的类型。可能的值为 Text 和 HTML。
/// </summary>
public enum ContentType
{
    [Description( "HTML" )]
    HTML,

    [Description( "Text" )]
    Text
}