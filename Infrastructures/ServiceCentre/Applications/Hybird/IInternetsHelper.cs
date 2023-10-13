using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

public interface IInternetsHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="internetHost"></param>
    /// <param name="internetResource"></param>
    /// <param name="internetResponse"></param>
    /// <returns></returns>
    Task<bool> SendRequest(
        IInternetHost internetHost, 
        IInternetResource internetResource,
        out IInternetResponse internetResponse);
}

