
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-rest-7.0&tabs=HTTP#definitions
    /// </summary>
    public class ItemsGet
    {
        public string Path { get; set; }

        public bool Download { get; set; }

        public string FileName { get; set; }

        public bool IncludeContent { get; set; }

        public VersionControlRecursionType RecursionLevel { get; set; }

        public string ScopePath { get; set; }

        public SubCondition.VersionDescriptor VersionDescriptor { get; set; }
    }
}
