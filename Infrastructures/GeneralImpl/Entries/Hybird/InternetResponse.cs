//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Hybird;

public class InternetResponse : OneObject, IInternetResponse
{
    public InternetResponse() {}

    public HttpStatus StatusCode { get; set; }

    public IInternetData Response { get; set; }
}