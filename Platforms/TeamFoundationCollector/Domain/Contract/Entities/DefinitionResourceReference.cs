using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/authorizedresources/authorize-project-resources?view=azure-devops-server-rest-6.0
    /// </summary>
    public class DefinitionResourceReference
    {
        /// <summary>
        /// Indicates whether the resource is authorized for use.
        /// </summary>
        public bool Authorized { get; set; }

        /// <summary>
        /// The id of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A friendly name for the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the resource.
        /// </summary>
        public string Type { get; set; }
    }
}
