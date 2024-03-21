//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.Common.Enums;

/// <summary>
/// 哈希算法枚举
/// </summary>
public enum HashType
{
    /// <summary>
    /// MD5
    /// </summary>
    [Description( "MD5" )]
    MD5 = 0,

    /// <summary>
    /// SHA1
    /// </summary>
    [Description( "SHA1" )]
    SHA1 = 1,

    /// <summary>
    /// SHA256
    /// </summary>
    [Description( "SHA256" )]
    SHA256 = 2,

    /// <summary>
    /// SHA384
    /// </summary>
    [Description( "SHA384" )]
    SHA384 = 3,

    /// <summary>
    /// SHA512
    /// </summary>
    [Description( "SHA512" )]
    SHA512 = 4
}