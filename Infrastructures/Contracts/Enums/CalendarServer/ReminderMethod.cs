using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 提醒方法
/// </summary>
public enum ReminderMethod
{
    /// <summary>
    /// Reminders are sent via email.
    /// </summary>
    [JsonProperty("email")]
    Email,

    /// <summary>
    /// Reminders are sent via SMS.These are only available for G Suite customers.
    /// Requests to set SMS reminders for other account types are ignored.
    /// </summary>
    [JsonProperty("sms")]
    Sms,

    /// <summary>
    /// Reminders are sent via a UI popup.
    /// </summary>
    [JsonProperty("popup")]
    Popup
}
