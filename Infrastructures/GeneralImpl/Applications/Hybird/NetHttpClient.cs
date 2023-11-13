using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Hybird;

public class NetHttpClient:OneImplement,IInternetsHelper
{
	public NetHttpClient()
	{
	}

    public Task<bool> TryRequest(
        IInternetHost internetHost,
        IInternetResource internetResource,
        out IInternetResponse internetResponse)
    {
        internetResponse = null;
        return Task.FromResult( true);
    }
}

