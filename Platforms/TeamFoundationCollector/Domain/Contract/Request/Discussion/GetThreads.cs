using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Discussion
{
	public class GetThreads
		:PresetRequest,IRequest
    {
        public string Method { get; set; } = "Get";

        public ArtifactUri? Uri { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/_apis/discussion/threads";

        public string RequestQuery() => $"?artifactUri={Uri}";

        public string RequestBody() => string.Empty;
    }
}

