using System;
namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums
{
    /// <summary>
    /// Expand options. Default is None.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/logs/get?view=azure-devops-rest-7.0#getlogexpandoptions
    /// </summary>
    public enum GetLogExpandOptions
	{
		None,

        SignedContent
    }
}

