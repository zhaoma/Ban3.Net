using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
	public class GetPortrait
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        public string Descriptor { get; set; } = string.Empty;

        public string RequestPath() => $"{Instance}/{Organization}/_apis/GraphProfile/MemberAvatars/{Descriptor}";

        public string RequestQuery() => string.Empty; //$"?id={Id}&api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

