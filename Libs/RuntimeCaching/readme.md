T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, DateTime absoluteTime)

T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, int minutes)

T LoadOrSetDefault<T>(this string key, Func<T> defaultValue, string localFile)

T LoadOrSetDefault<T>(this string key, string localFile)

T LoadOrSetDefault<T>(this string key, Func<T> defaultValue,DateTime? absoluteTime, int? minutes,string localFile)
