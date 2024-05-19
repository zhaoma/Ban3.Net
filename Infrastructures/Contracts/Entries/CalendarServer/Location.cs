//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums;
using Ban3.Infrastructures.Contracts.Materials;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 地址
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/location
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/physicaladdress
/// </summary>
public class Location:ILocation
{
    public IPhysicalAddress? Address { get; set; }

    public IGeoCoordinates? Coordinates { get; set; }

    public string DisplayName { get; set; }

    public string LocationEmailAddress { get; set; }

    public string LocationUri { get; set; }

    public LocationType LocationType { get; set; }
}
