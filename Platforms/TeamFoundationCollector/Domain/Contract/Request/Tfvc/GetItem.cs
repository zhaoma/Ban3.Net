
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc
{
    /// <summary>
    /// Get Item Metadata and/or Content for a single item.
    /// The download parameter is to indicate whether the content should be available as a download or just sent as a stream in the response.
    /// Doesn't apply to zipped content which is always returned as a download.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetItem
        : PresetRequest, IRequest
    {
        /// <summary>
        /// Version control path of an individual item to return.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// If true, create a downloadable attachment.
        /// </summary>
        public bool Download { get; set; }

        /// <summary>
        /// file name of item returned.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Set to true to include item content when requesting json.
        /// Default is false.
        /// </summary>
        public bool IncludeContent { get; set; }

        public VersionControlRecursionType RecursionLevel { get; set; }= VersionControlRecursionType.None;

        public string ScopePath { get; set; } = string.Empty;

        public SubCondition.VersionDescriptor? VersionDescriptor { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/items";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");

            sb.AppendQuery("path", Path);

            if (!string.IsNullOrEmpty(Path))
                sb.Append($"path={Path}&");

            if (!string.IsNullOrEmpty(FileName))
                sb.Append($"fileName={FileName}&");

            sb.Append($"download={Download}&");
            sb.Append($"includeContent={IncludeContent}&");
            sb.Append($"recursionLevel={RecursionLevel}&");

            if (!string.IsNullOrEmpty(ScopePath))
                sb.Append($"scopePath={ScopePath}&");

            if (VersionDescriptor != null)
            {
                sb.Append($"versionDescriptor.version={VersionDescriptor.Version }&");
                sb.Append($"versionDescriptor.versionOption={VersionDescriptor.VersionOption}&");
                sb.Append($"versionDescriptor.versionType={VersionDescriptor.VersionType}&");
            }

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

    }
}
