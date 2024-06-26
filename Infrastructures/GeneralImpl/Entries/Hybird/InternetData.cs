﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.IO;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Hybird;

public class InternetData : OneObject, IInternetData
{
    public InternetData() {}

    public byte[] Bytes { get; set; }

    public Stream StreamContent { get; set; }

    public string StringContent { get; set; }

    public string ContentMediaType { get; set; }

    public string ContentEncoding { get; set; }
}