using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// The online meeting service providers that can be used to create online meetings in this calendar.
/// </summary>
public enum OnlineMeetingProviderType
{
    Unknown,
    SkypeForBusiness,
    SypeForConsumer,
    TeamsForBusiness
}
