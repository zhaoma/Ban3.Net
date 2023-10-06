using System;
namespace Ban3.Infrastructures.ServiceCentre.Response;

public class SetCacheResult<T>
{
	public SetCacheResult()
	{
	}

	public T Data { get; set; }
}

