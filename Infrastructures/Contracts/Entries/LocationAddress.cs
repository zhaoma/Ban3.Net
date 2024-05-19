//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums;
using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries;

/// <summary>
/// Represents the street address of a resource such as a contact or event.
/// </summary>
public class LocationAddress : IPhysicalAddress
{
    public PhysicalAddressType Type { get; set; }

    public string City { get; set; } = string.Empty;

    public string CountryOrRegion { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public string PostOfficeBox { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;
}
