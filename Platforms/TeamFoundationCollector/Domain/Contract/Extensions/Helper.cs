using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using log4net;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial  class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    #region string parse

    public static string ShowName(this string displayName)
    {
        if (string.IsNullOrEmpty(displayName)) return "-";

        try
        {
            return displayName.Substring(0, (displayName + "").IndexOf("(", StringComparison.Ordinal));
        }
        catch (Exception) { }

        return displayName;
    }

    public static string ShowTitle(this string displayName)
    {
        if (string.IsNullOrEmpty(displayName)) return "-";

        try
        {
            var start = (displayName + "").IndexOf("(", StringComparison.Ordinal) + 1;
            return displayName.Substring(start, (displayName + "").IndexOf(")", StringComparison.Ordinal) - start);
        }
        catch (Exception) { }

        return displayName;
    }

    public static string ShowDate(this string dateString)
    {
        try
        {
            return dateString.ToDateTime()
                .ToLocalTime().ToString("yyyy-MM-dd HH:mm");
        }
        catch (Exception) { }

        return dateString;
    }

    public static string ShowYear(this string dateString)
    {
        try
        {
            return dateString.ToDateTime()
                .ToLocalTime().ToString("yyyy-MM-dd");
        }
        catch (Exception) { }

        return dateString;
    }

    #endregion

    #region request parse

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
                var key = attribute.PropertyName;
                var val = prop.GetValue(obj);
                var type = prop.PropertyType;

                var isPrimitive = type.IsValueType || type == typeof(string);

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

    #endregion

    public static bool IsIgnored(this string str)
        => Config.IgnoredKeys.Any(str.Contains);

    public static bool PersistFileOnDemand<T>(this string filePath, T content)
    {
        try
        {
            var timestamp = content!.ObjToJson().MD5String();

            var foundTimestamp = PersistFilesTimestampDic.TryGetValue(filePath, out var ts);
            if (foundTimestamp && ts != null && ts.Equals(timestamp))
            {
                Console.Write("_");
                return true;
            }

            if (!foundTimestamp)
            {
                ts = filePath.ReadFile().MD5String();
                if (ts.Equals(timestamp))
                {
                    Console.Write(".");
                    return true;
                }
                else
                {
                    Console.Write("+");
                }
            }

            filePath.WriteFile(content!.ObjToJson());
            PersistFilesTimestampDic.AddOrReplace(filePath, timestamp);

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
        
        return false;
    }

    private static readonly Dictionary<string, string> PersistFilesTimestampDic = new();
}