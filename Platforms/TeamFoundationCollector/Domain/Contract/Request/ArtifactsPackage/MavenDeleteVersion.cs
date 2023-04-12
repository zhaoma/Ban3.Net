using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.TeamFoundationCollector.Infrastructrue.Common.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.ArtifactsPackage
{
    public class MavenDeleteVersion
        : IRequest
    {
        /// <summary>
        /// Name or ID of the feed.
        /// </summary>
        public string Feed { get; set; }

        /// <summary>
        /// Group ID of the package.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Version of the package.
        /// </summary>
        public string Version { get; set; }
    }
}
