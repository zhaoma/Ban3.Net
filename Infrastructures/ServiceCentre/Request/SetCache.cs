using System;
namespace Ban3.Infrastructures.ServiceCentre.Request;

public class SetCache<T>
{
	public SetCache()
	{
	}

	public Entries.CacheItem<T> CacheItem { get; set; }
}

