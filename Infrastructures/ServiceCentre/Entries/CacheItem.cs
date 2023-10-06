using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries;

public class CacheItem<T>
{
	public CacheItem()
	{
	}

	public CacheItem(string key, T value)
	{
		Key = key;
		Value = value;
	}

	public string Key { get; set; }

	public T Value { get; set; }

	public Enums.CacheDependency CacheDependency { get; set; }

	public DateTime? AbsoluteTime { get; set; }

	public TimeSpan? RelativeTime { get; set; }

	public string File { get; set; }
}

