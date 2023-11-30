﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 
/// </summary>
public interface IInternetsHelper
{
    /// <summary>
    /// CommandLine Uniform Resource Locator
    /// </summary>
    /// <param name="internetHost"></param>
    /// <param name="internetResource"></param>
    /// <param name="internetResponse"></param>
    /// <returns></returns>
    Task<bool> TryRequest(
        IInternetHost internetHost,
        IInternetResource internetResource,
        Action<IInternetResponse> internetResponse );

    /// <summary>
    /// anonymous request
    /// </summary>
    /// <param name="internetResource"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryRequest(
        IInternetResource internetResource,
        Action<IInternetResponse> action
    );
}