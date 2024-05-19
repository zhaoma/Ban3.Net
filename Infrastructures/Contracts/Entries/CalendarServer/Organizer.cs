//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class Organizer : IOrganizer
{
    public string DisplayName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;

    public bool Self { get; set; }

    public IEmailAddress? EmailAddress { get; set; }
}
