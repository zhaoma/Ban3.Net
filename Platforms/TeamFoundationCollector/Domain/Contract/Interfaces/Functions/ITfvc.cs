using System;
namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions
{
	public interface ITfvc
    {
        IChangesets Changesets { get; set; }
    }

	public interface  IChangesets{}
}

