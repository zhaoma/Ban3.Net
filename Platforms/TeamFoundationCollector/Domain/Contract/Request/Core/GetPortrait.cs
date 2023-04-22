using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
	public class GetPortrait
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        public string Id { get; set; } = string.Empty;

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_api/_common/identityImage";

        public string RequestQuery() => $"?id={Id}&api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

