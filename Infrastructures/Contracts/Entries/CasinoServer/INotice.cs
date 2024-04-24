//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;


public interface INotice
{
    string Code { get; set; }

    DateTime MarkTime { get; set; }

    string Note {  get; set; }
}
