using System;
namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums
{
    /// <summary>
    /// Expand options. Default is None.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/artifacts/get?view=azure-devops-rest-7.0#getartifactexpandoptions
    /// </summary>
    public enum GetArtifactExpandOptions
	{
        /// <summary>
        /// No expansion.
        /// </summary>
		None,

        /// <summary>
        /// Include signed content.
        /// </summary>
        SignedContent
    }
}

