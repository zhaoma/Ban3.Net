using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc
{
    /// <summary>
    /// Get a single branch hierarchy at the given path with parents or children as specified.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get?view=azure-devops-rest-7.0&tabs=HTTP
    /// </summary>
    public class GetBranch
        : PresetRequest,IRequest
    {
        public string Method { get; set; } = "Get";
        
        /// <summary>
        /// Full path to the branch.
        /// Default: $/
        /// Examples: $/, $/MyProject, $/MyProject/SomeFolder.
        /// </summary>
        public string Path { get; set; } = "$/";

        /// <summary>
        /// Return child branches, if there are any.
        /// Default: False
        /// </summary>
        public bool IncludeChildren { get; set; } = false;

        /// <summary>
        /// Return the parent branch, if there is one.
        /// Default: False
        /// </summary>
        public bool IncludeParent { get; set; } = false;
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/branches";

        public string RequestQuery() => $"?path={Path}&includeChildren={IncludeChildren}&includeParent={IncludeParent}&api-version={ApiVersion}";

        public string RequestBody() => string.Empty;

    }
}
