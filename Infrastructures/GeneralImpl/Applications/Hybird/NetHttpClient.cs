// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.Threading.Tasks;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Hybird;

public class NetHttpClient : OneImplement, IInternetsHelper
{
    public NetHttpClient() {}

    public Task<bool> TryRequest(
        IInternetHost internetHost,
        IInternetResource internetResource,
        out IInternetResponse internetResponse )
    {
        internetResponse = null;
        return Task.FromResult( true );
    }
}