using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Ban3.Infrastructures.Common.Extensions;
using log4net;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial  class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    static readonly object ObjLock = new object();

    static readonly ReaderWriterLockSlim LockSlim = new ReaderWriterLockSlim();

    const int LockSlimTimeout = 1000;
    public static string ShowName(this string displayName)
    {
        if (string.IsNullOrEmpty(displayName)) return "-";

        try
        {
            return displayName.Substring(0, (displayName + "").IndexOf("("));
        }
        catch (Exception) { }

        return displayName;
    }

    public static string ShowTitle(this string displayName)
    {
        if (string.IsNullOrEmpty(displayName)) return "-";

        try
        {
            var start = (displayName + "").IndexOf("(") + 1;
            return displayName.Substring(start, (displayName + "").IndexOf(")") - start);
        }
        catch (Exception) { }

        return displayName;
    }

    public static string ShowDate(this string dateString)
    {
        try
        {
            return dateString.ToDateTime()
                .ToLocalTime().ToString("MM-dd HH:mm");
        }
        catch (Exception) { }

        return dateString;
    }

    public static bool IsIgnored(this string str)
        => Config.IgnoredKeys.Any(str.Contains);

    public static string ToQueryString(this Dictionary<string, object> dic)
    {
        var sb = new StringBuilder();

        sb.Append("?");

        foreach (var item in dic)
        {
            sb.AppendQuery(item.Key, item.Value.ToString());
        }

        return sb.ToString();
    }

    public static Dictionary<string, object> ToDictionary(this Object obj)
    {
        var result = new Dictionary<string, object>();

        obj.Parse(result);

        return result;
    }

    public static void Parse(
            this object obj,
            Dictionary<string, object> keyValuePairs,
            string prefix = "")
    {
        var properties = obj.GetType()
                            .GetProperties();


        foreach (var prop in properties)
        {
            var attribute = prop.GetCustomAttribute<JsonPropertyAttribute>();
            if (attribute != null)
            {
                var key = attribute?.PropertyName;
                var val = prop?.GetValue(obj);
                var type = prop?.PropertyType;

                var isPrimitive = type != null && (type.IsValueType || type == typeof(string));

                if (!isPrimitive)
                {
                    val?.Parse(keyValuePairs, key + "");
                }
                else
                {
                    if (key != null && val != null)
                    {
                        var newKey = string.IsNullOrEmpty(prefix)
                                             ? key
                                             : $"{prefix}.{key}";
                        keyValuePairs.Add(newKey, val);
                    }
                }
            }
        }
    }


}