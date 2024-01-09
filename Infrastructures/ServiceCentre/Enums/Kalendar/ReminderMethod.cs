//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Kalendar;

/// <summary>
/// 提醒方法
/// The method used by this reminder. Possible values are:
/// "email" - Reminders are sent via email.
/// "sms" - Reminders are sent via SMS.These are only available for G Suite customers.Requests to set SMS reminders for other account types are ignored.
/// "popup" - Reminders are sent via a UI popup.
/// Required when adding a reminder.
/// </summary>
public enum ReminderMethod
{
    [Description( "email" )]
    Email,

    [Description( "sms" )]
    SMS,

    [Description( "popup" )]
    Popup
}