//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

/// <summary>
/// 时间信息
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/datetimetimezone
/// </summary>
public interface ITime : IZero
{
    /// <summary>
    /// 日期(GOOGLE)
    /// The date, in the format "yyyy-mm-dd", if this is an all-day event.
    /// </summary>
    string Date { get; set; }

    /// <summary>
    /// 日期/时间(MS)
    /// The time, as a combined date-time value (formatted according to RFC3339). 
    /// A time zone offset is required unless a time zone is explicitly specified in timeZone.
    /// https://tools.ietf.org/html/rfc3339
    /// 注意:OUTLOOK只有DateTime没有Date
    /// </summary>
    string DateTime { get; set; }

    /// <summary>
    /// 时区
    /// The time zone in which the time is specified. (Formatted as an IANA Time Zone Database name, e.g. "Europe/Zurich".) 
    /// For recurring events this field is required and specifies the time zone in which the recurrence is expanded. 
    /// For single events this field is optional and indicates a custom time zone for the event start/end.
    /// </summary>
    string TimeZone { get; set; }

    /*
     * 
     * The TimeZone property can be set to any of the time zones supported by Windows, 
     * as well as the following time zones names.
     * 
     * 
     Etc/GMT+12
     Etc/GMT+11
     Pacific/Honolulu
     America/Anchorage
     America/Santa_Isabel
     America/Los_Angeles
     America/Phoenix
     America/Chihuahua
     America/Denver
     America/Guatemala
     America/Chicago
     America/Mexico_City
     America/Regina
     America/Bogota
     America/New_York
     America/Indiana/Indianapolis
     America/Caracas
     America/Asuncion
     America/Halifax
     America/Cuiaba
     America/La_Paz
     America/Santiago
     America/St_Johns
     America/Sao_Paulo
     America/Argentina/Buenos_Aires
     America/Cayenne
     America/Godthab
     America/Montevideo
     America/Bahia
     Etc/GMT+2
     Atlantic/Azores
     Atlantic/Cape_Verde
     Africa/Casablanca
     Etc/GMT
     Europe/London
     Atlantic/Reykjavik
     Europe/Berlin
     Europe/Budapest
     Europe/Paris
     Europe/Warsaw
     Africa/Lagos
     Africa/Windhoek
     Europe/Bucharest
     Asia/Beirut
     Africa/Cairo
     Asia/Damascus
     Africa/Johannesburg
     Europe/Kyiv (Kiev)
     Europe/Istanbul
     Asia/Jerusalem
     Asia/Amman
     Asia/Baghdad
     Europe/Kaliningrad
     Asia/Riyadh
     Africa/Nairobi
     Asia/Tehran
     Asia/Dubai
     Asia/Baku
     Europe/Moscow
     Indian/Mauritius
     Asia/Tbilisi
     Asia/Yerevan
     Asia/Kabul
     Asia/Karachi
     Asia/Toshkent (Tashkent)
     Asia/Kolkata
     Asia/Colombo
     Asia/Kathmandu
     Asia/Astana (Almaty)
     Asia/Dhaka
     Asia/Yekaterinburg
     Asia/Yangon (Rangoon)
     Asia/Bangkok
     Asia/Novosibirsk
     Asia/Shanghai
     Asia/Krasnoyarsk
     Asia/Singapore
     Australia/Perth
     Asia/Taipei
     Asia/Ulaanbaatar
     Asia/Irkutsk
     Asia/Tokyo
     Asia/Seoul
     Australia/Adelaide
     Australia/Darwin
     Australia/Brisbane
     Australia/Sydney
     Pacific/Port_Moresby
     Australia/Hobart
     Asia/Yakutsk
     Pacific/Guadalcanal
     Asia/Vladivostok
     Pacific/Auckland
     Etc/GMT-12
     Pacific/Fiji
     Asia/Magadan
     Pacific/Tongatapu
     Pacific/Apia
     Pacific/Kiritimati
     */
}
