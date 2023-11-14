// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Hybird;

public class InternetHost : OneObject, IInternetHost
{
    public InternetHost() {}

    public AuthenticationType AuthenticationType { get; set; }

    public string Domain { get; set; }

    public string BaseUrl { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
}